using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Rockstars_Frontend.Models { 
    public class Post
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int ThumbnailId { get; set; }
        
        [ForeignKey(nameof(ThumbnailId))]
        public StoredFile Thumbnail { set; get; }

        public int AuthorId { get; set; }
        
        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }

        public int TribeId { get; set; }
        
        [ForeignKey(nameof(TribeId))]
        public Tribe Tribe { get; set; }

        [Required]
        public PostType Type { get; set; }

        public PostStatus Status { get; set; } = PostStatus.Concept;

        [Required]
        public IList<PostAttribute> Attributes { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}