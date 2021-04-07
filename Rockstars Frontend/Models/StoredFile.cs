using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Rockstars.WebApi.Data;

namespace Rockstars.WebApi.Models
{
    public class StoredFile : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]

        public string Path { get; set; }

        [NotMapped]
        public string Url => $"/api/File/{Id}/retrieve"; //TODO: Change hardcoded string to dynamically assign based on controller and action route

        public string ContentType { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IEnumerable<byte> Content { get; set; }
    }
}