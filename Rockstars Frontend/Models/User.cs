using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Rockstars.WebApi.Data;

namespace Rockstars.WebApi.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Biography { get; set; }

        public UserRole Role { get; set; }

        public int ImageId { get; set; }

        [BindNever]
        [ForeignKey(nameof(ImageId))]
        public StoredFile Image { get; set; }
    }
}