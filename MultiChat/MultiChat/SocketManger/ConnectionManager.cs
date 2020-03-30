using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiChat.SocketManager
{
    public class ConnectionManager
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public ConcurrentDictionary<string, WebSocket> GetAllConnections()
        {
            return _sockets;
        }

        public string GetId(WebSocket socket)
        {
            return _sockets.FirstOrDefault(p => p.Value == socket).Key;
        }
        public void AddSocket(WebSocket socket)
        {
            _sockets.TryAdd(GetConnectionId(), socket);
        }

        public async Task RemoveSocket(string id)
        {
            WebSocket socket;
            _sockets.TryRemove(id, out socket);

            await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                    statusDescription: "Closed by the ConnectionManager",
                                    cancellationToken: CancellationToken.None);
        }

        private string GetConnectionId()
        {
            return Guid.NewGuid().ToString();
        }
    }
    public abstract class SocketHandler
    {
        public ConnectionManager Connections { get; set; }
        public SocketHandler (ConnectionManager connections)
        {
            Connections = connections;
        }
        public virtual async Task OnConnected (WebSocket Socket)
        {
            await Task.Run(() => { Connections.AddSocket(Socket); });
        }
        public virtual async Task OnDisconnected(WebSocket socket)
        {
            await Connections.RemoveSocket(Connections.GetId(socket));
        }
        public virtual async Task SendMessage(WebSocket socket,String message)
        {
            if (socket.State != WebSocketState.Open)
                return;
            await socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(message),0,message.Length),WebSocketMessageType.Text,true,CancellationToken.None);  
        }
        public async Task SendMessage(String id,string message)
        {
            await SendMessage(Connections.GetSocketById(id), message);
        }
        public async Task SendMessageToAll(string message)
        {
            foreach (var con in Connections.GetAllConnections())
                await SendMessage(con.Value, message);
        }
        public abstract Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
    }
    public static class SocketsExtension
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection services)
        {
            services.AddTransient<ConnectionManager>();
            foreach(var type in Assembly.GetEntryAssembly().ExportedTypes)
            {
                if (type.GetTypeInfo().BaseType == typeof(SocketHandler))
                    services.AddSingleton(type);
            }
            return services; 
        }
        public static IApplicationBuilder MapSockets(this IApplicationBuilder app,PathString path,SocketHandler socket)
        {
            return app.Map(path, (x) => x.UseMiddleware<SocketMiddelware>(socket));
        }
    }
    public class SocketMiddelware
    {
        private readonly RequestDelegate _next;
        private SocketHandler Handler { get; set; }
        public SocketMiddelware(RequestDelegate next,SocketHandler handler)
        {
            _next = next;
            Handler = handler;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
                return;
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await Handler.OnConnected(socket);
            await Receive(socket,async(result,buffer)=>
            { if (result.MessageType == WebSocketMessageType.Text)
                {
                    await Handler.Receive(socket, result, buffer);
                }
                else if (result.MessageType == WebSocketMessageType.Close) 
                {
                    await Handler.OnConnected(socket);
                }
            });
        }

        private async Task Receive(WebSocket webSocket, Action<WebSocketReceiveResult,byte[]>messageHandler)
        {
            var buffer = new byte[1024 * 4];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                messageHandler(result, buffer);
            }
        }
    }
}
