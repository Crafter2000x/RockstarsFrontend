using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstars_Frontend
{
    public class TelemetryViewModel
    {
        public string fingerprint { get; set; }
        public string userAgent { get; set; }
        public TelemetryType type { get; set; }
        public IDictionary<string, string> properties { get; set; }

    }
}
