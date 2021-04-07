using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Rockstars.WebApi.Data;

namespace Rockstars.WebApi.Models
{
    public class Post : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [BindNever]
        [ForeignKey(nameof(ThumbnailId))]
        public StoredFile Thumbnail { set; get; }

        public int ThumbnailId { get; set; }

        public int AuthorId { get; set; }

        [BindNever]
        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }

        public int TribeId { get; set; }

        [BindNever]
        [ForeignKey(nameof(TribeId))]
        public Tribe Tribe { get; set; }

        [Required]
        public PostType Type { get; set; }

        public PostStatus Status { get; set; } = PostStatus.Concept;

        public IDictionary<string,string> Attributes { get; set; }
        
        [BindNever]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}