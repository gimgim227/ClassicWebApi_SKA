
using System.Collections.Generic;

namespace ClassicWebAPI.Models
{
    public class GetCountryBySubRegionResponse
    {
        public string SubRegion { get; set; }
        public List<string> Countries { get; set; }
    }
}
