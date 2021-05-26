using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstars_Frontend.Models
{
    public class FormulierEnAanvraagModel
    {
        public FormulierModel form { get; set; }
        public TalkModel talk { get; set; }

        public ArtikelModel art { get; set; }

        public List<User> userlist { get; set; }
    }
}
