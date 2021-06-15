using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rockstars_Frontend.Models
{
    public class StoredFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public string ContentType { get; set; }

        public string RelativeUrl => $"/api/File/{Id}/retrieve"; //TODO: Change hardcoded string to dynamically assign based on controller and action route

        public string AbsoluteUrl => $"https://i479146core.venus.fhict.nl/api/File/{Id}/retrieve";

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}