using System.ComponentModel.DataAnnotations;
using Rockstars.WebApi.Data;

namespace Rockstars.WebApi.Models
{
    public class Tribe : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}