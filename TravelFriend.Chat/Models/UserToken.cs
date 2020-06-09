using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class UserToken
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }

        public virtual User User { get; set; }
    }
}
