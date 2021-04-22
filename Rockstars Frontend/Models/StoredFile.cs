using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rockstars_Frontend.Models
{
    public class StoredFile
    {
        public string Name { get; set; }

        [Required]
        public string OriginalName { get; set; }

        [JsonIgnore]

        public string Path { get; set; }

        //[NotMapped]
        public string Url { get; set; } /*=> $"/api/File/{Id}/retrieve"; *///TODO: Change hardcoded string to dynamically assign based on controller and action route

        public string ContentType { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IEnumerable<byte> Content { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}