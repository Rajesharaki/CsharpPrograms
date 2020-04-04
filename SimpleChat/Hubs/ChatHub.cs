using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApplication.Models;
using Microsoft.AspNetCore.SignalR;
namespace ChatApplication.Hubs
{
    /// <summary>
    /// this class extends the Hub class from signalR
    /// </summary>
    public class ChatHub : Hub
    {
        private readonly DataDbContext context;

        /// <summary>
        /// injecting the DatabaseContext through the constructor
        /// </summary>
        /// <param name="context"></param>
        public ChatHub(DataDbContext context)
        {
            this.context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            
               await context.users.AddAsync(new User {UserName=user, Message=message});
            await context.SaveChangesAsync();
        }
    }
}
