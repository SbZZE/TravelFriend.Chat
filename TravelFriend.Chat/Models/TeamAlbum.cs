using System;
using System.Collections.Generic;

namespace TravelFriend.Chat.Models
{
    public partial class TeamAlbum
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Cover { get; set; }
        public string CompressCover { get; set; }
        public string Albumname { get; set; }
        public string Introduction { get; set; }
        public string Count { get; set; }
    }
}
