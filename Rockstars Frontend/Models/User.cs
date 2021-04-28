using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rockstars_Frontend.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        public string Biography { get; set; }

        public int ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public StoredFile Image { get; set; }

        [JsonIgnore]
        public List<TribeMember> MemberOf { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}