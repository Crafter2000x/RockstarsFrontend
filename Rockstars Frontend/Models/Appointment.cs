using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rockstars_Frontend.Models
{
    public class Appointment
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int AmountOfPeople { get; set; }
        
        [Required]
        public DateTime PreferredDateTime { get; set; }

        [Required]
        public int TribeId { get; set; }
        
        [ForeignKey(nameof(TribeId))]
        public Tribe Tribe { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required]
        public string ContactEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        public string Comment { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}