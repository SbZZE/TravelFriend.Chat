﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelFriend.Chat.Models;

namespace TravelFriend.Chat.IRepository
{
    public interface IChatRepository
    {
        Task<List<TeamMember>> GetTeamsByUserName(string userName);
    }
}
