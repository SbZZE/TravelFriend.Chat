using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class UserTeam
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string TeamName { get; set; }
        public string Avatar { get; set; }
        public string CompressAvatar { get; set; }
        public string Introduction { get; set; }

        public virtual User User { get; set; }
    }
}
