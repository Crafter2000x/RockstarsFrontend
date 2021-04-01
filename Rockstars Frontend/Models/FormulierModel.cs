using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstars_Frontend.Models
{
    public class FormulierModel
    {
        [DataType(DataType.Date)]
        public DateTime voorkeursDag { get; set; }

        public string bedrijfsNaam { get; set; }
        public int aantalMensenAanwezig { get; set; }
        public Tribes tribe { get; set; }

        [DataType(DataType.MultilineText)]
        public string opmerking { get; set; }
        [DataType(DataType.EmailAddress)]
        public string contactEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string telefoonNummer { get; set; }


    }

    public enum Tribes
    {
        Microsoft,
        JavaScript,
        Python,
    }
}
