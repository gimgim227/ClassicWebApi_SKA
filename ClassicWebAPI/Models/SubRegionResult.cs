using System.Collections.Generic;

namespace ClassicWebAPI.Models
{
    public class SubRegionResult
    {
        public string SubRegion { get; set; }
        public IEnumerable<string> Countries { get; set; }
    }
}
