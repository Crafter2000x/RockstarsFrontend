using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rockstars_Frontend.Models
{
    public class ArtikelModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public StoredFile Thumbnail { set; get; }

        public int ThumbnailId { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int TribeId { get; set; }

        public Tribe Tribe { get; set; }

        public int Type { get; set; }

        public int Status { get; set; }

        public IDictionary<string, string> Attributes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
