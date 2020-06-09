using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Chat
{
    public class ChatHub : Hub
    {
        public async Task SendMessage()
        {
            int count = 0;
            string name = "sbzhangzhier";
            while (true)
            {
                count++;
                await Clients.User(name).SendAsync("ReceiveMessage", name, count);
                await Task.Delay(1000);
            }
        }

        public async override Task OnConnectedAsync()
        {
            var a = Context.ConnectionId;
            var b = Context.User;
            var c = Context.UserIdentifier;
            await SendMessage();
            await base.OnConnectedAsync();
        }
    }
}
