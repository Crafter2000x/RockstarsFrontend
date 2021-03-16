using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstars_Frontend.Models
{
    public class ArtikelModel
    {
        public class Thumbnail
        {
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string contentType { get; set; }
        }


        public class Pdf
        {
            public int id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string contentType { get; set; }
        }
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int status { get; set; }

        public Thumbnail thumbnail { get; set; }
        public Pdf pdf { get; set; }
        public int thumbnailId { get; set; }

        public DateTime createdDate { get; set; }

    }
}
