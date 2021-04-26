using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rockstars_Frontend.Models
{
    public class Tribe
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        public IList<TribeMember> Members { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
    }
}