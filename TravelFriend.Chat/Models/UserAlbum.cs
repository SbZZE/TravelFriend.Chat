using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class UserAlbum
    {
        public UserAlbum()
        {
            AlbumImages = new HashSet<AlbumImages>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Albumname { get; set; }
        public string Introduction { get; set; }
        public string Cover { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<AlbumImages> AlbumImages { get; set; }
    }
}
