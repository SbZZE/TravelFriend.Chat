using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class TeamMember
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string MemberName { get; set; }
        public string MemberNickname { get; set; }
        public string Isleader { get; set; }
    }
}
