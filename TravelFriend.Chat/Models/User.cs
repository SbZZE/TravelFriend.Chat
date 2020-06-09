using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class User
    {
        public User()
        {
            UserAlbum = new HashSet<UserAlbum>();
            UserTeam = new HashSet<UserTeam>();
            UserToken = new HashSet<UserToken>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Signature { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string CompressAvatar { get; set; }

        public virtual ICollection<UserAlbum> UserAlbum { get; set; }
        public virtual ICollection<UserTeam> UserTeam { get; set; }
        public virtual ICollection<UserToken> UserToken { get; set; }
    }
}
