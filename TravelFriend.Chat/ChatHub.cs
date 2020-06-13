using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Chat.IRepository;

namespace TravelFriend.Chat
{
    public class ChatHub : Hub
    {
        //用户的connectionId与用户名对照
        private readonly static Dictionary<string, string> _connections = new Dictionary<string, string>();
        private readonly IChatRepository _chatRepository;

        public ChatHub(IChatRepository chatRepository) : base()
        {
            _chatRepository = chatRepository;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// 用户登录聊天服务器
        /// </summary>
        /// <param name="userName"></param>
        public async Task UserLogin(string userName)
        {
            _connections.Add(Context.ConnectionId, userName);
            var teams = await _chatRepository.GetTeamsByUserName(userName);
            foreach (var team in teams)
            {
                //将用户加入到每个他所在的群组通知中
                await Groups.AddToGroupAsync(Context.ConnectionId, team.Id);
                //像用户所在的群组发登录通知
                await Clients.Group(team.Id).SendAsync("Login", userName, team.Id);
            }
        }

        /// <summary>
        /// 发送消息给团队
        /// </summary>
        /// <param name="message"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task SendMessage(string teamId, string nickName, string sendTime, string content)
        {
            var userName = _connections.FirstOrDefault(x => x.Key == Context.ConnectionId).Value;
            if (userName != null)
            {
                await Clients.Group(teamId).SendAsync("Received", teamId, userName, nickName, sendTime, content);
            }
        }

        /// <summary>
        /// 用户退出聊天服务器
        /// </summary>
        public async Task UserLogout()
        {
            var userName = _connections.FirstOrDefault(x => x.Key == Context.ConnectionId).Value;
            _connections.Remove(Context.ConnectionId);
            var teams = await _chatRepository.GetTeamsByUserName(userName);
            foreach (var team in teams)
            {
                //将用户加入到每个他所在的群组通知中
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, team.Id);
                //像用户所在的群组发登录通知
                await Clients.Group(team.Id).SendAsync("Logout", userName, team.Id);
            }
        }
    }
}
