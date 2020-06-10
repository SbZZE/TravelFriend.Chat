using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelFriend.Chat
{
    public class ChatHub : Hub
    {
        //静态的用户列表
        private static IList<string> UserList = new List<string>();
        //用户的connectionId与用户名对照
        private readonly static Dictionary<string, string> _connections = new Dictionary<string, string>();

        /// <summary>
        /// 用户登录聊天服务器
        /// </summary>
        /// <param name="userName"></param>
        public async Task UserLogin(string userName)
        {
            if (!UserList.Contains(userName))
            {
                UserList.Add(userName);
                _connections.Add(userName, Context.ConnectionId);
            }
            else
            {
                _connections[userName] = Context.ConnectionId;
            }
            await Clients.AllExcept(Context.ConnectionId).
               SendAsync("GroupTip", $"{userName} 进入了群聊！");
        }

        public async Task SignOut(string name)
        {
            await Clients.AllExcept(Context.ConnectionId)
                .SendAsync("online", $"{name} 离开了群聊！");
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
