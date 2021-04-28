using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Rockstars_Frontend.Models
{
    public class PodcastModel
    {
        public int Id { get; set; }
        public string title { get; set; } 
        public string description { get; set; } 
        public int ThumbnailId { get; set; }
        public StoredFile Thumbnail { set; get; }
        public int AuthorId { get; set; }
        public User Author { get; set; } 

        public int TribeId { get; set; }

        public Tribe Tribe { get; set; }

        public int type { get; set; }
        public int status { get; set; }
        public IDictionary<string, string> attributes { get; set; }


    }


}
