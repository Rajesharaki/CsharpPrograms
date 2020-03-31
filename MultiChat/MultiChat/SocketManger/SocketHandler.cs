using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiChat.SocketManager
{
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
}
