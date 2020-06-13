using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Chat.IRepository;
using TravelFriend.Chat.Models;

namespace TravelFriend.Chat.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly TravelFriendContext _context;

        public ChatRepository(TravelFriendContext context)
        {
            _context = context;
        }

        public Task<List<TeamMember>> GetTeamsByUserName(string userName)
        {
            return _context.TeamMember.Where(x => x.MemberName == userName).ToListAsync();
        }
    }
}
