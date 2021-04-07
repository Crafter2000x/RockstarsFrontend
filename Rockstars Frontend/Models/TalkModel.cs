using Rockstars.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstars_Frontend.Models
{
    public class TalkModel
    {
        public class Thumbnail
        {
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string contentType { get; set; }
        }

        public int id { get; set; }
        public string title { get; set; }
        public User author { get; set; }

        //nog in API
        public Tribe Tribe { get; set; }

        public string description { get; set; }
        public int Status { get; set; }

        public StoredFile thumbnail { get; set; }

        public int Type { get; set; }

        public int thumbnailId { get; set; }

        public DateTime createdDate { get; set; }
    }
}
