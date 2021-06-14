using System.Collections.Generic;

namespace Rockstars_Frontend.Models
{
    public class TalksViewModel
    {
        public List<TalkModel> talks = new List<TalkModel>();
        public FormulierModel form { get; set; }
    }
}
