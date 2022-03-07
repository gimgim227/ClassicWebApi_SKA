using Newtonsoft.Json;

namespace ClassicWebAPI.Models
{
    public class SubRegionRequest
    {
        [JsonProperty("SubRegion")]
        public string SubRegion { get; set; }
    }
}
