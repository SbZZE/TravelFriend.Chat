using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class AlbumImages
    {
        public string Id { get; set; }
        public string AlbumId { get; set; }
        public string Image { get; set; }
        public string CompressImage { get; set; }
        public string Video { get; set; }

        public virtual UserAlbum Album { get; set; }
    }
}
