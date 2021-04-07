using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Rockstars.WebApi.Models;

namespace Rockstars_Frontend.Models
{
    public class FormulierModel
    {
        public string companyName { get; set; }
        public int amountOfPeople { get; set; }

        [DataType(DataType.Date)]
        public DateTime preferredDateTime { get; set; }
        public int tribeId { get; set; }
        public Tribe tribe { get; set; }

        [DataType(DataType.EmailAddress)]
        public string contactEmail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        public string comment { get; set; }
    }

    public enum Tribes
    {
        Microsoft,
        JavaScript,
        Python,
    }
}
