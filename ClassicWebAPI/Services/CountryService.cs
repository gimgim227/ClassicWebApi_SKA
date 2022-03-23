using ClassicWebAPI.Models;
using ClassicWebAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicWebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly IHttpClientService _httpClientService;

        public CountryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<CountryInfo>> GetAll()
        {
            var data = await GetCounttyAPIAsync("all");
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
        }
        public async Task<CountryInfo> GetMapByCountryName(string country)
        {
            var data = await GetCounttyAPIAsync("name/" + country);
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data).FirstOrDefault();
        }
        public async Task<List<string>> GetCountryNamesBySubRegion(string subRegion)
        {
            var data = await GetCounttyAPIAsync("subregion/" + subRegion);
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data)?
                .Select(x => x.CountryName.Common)
                .ToList();
        }
        private async Task<string> GetCounttyAPIAsync(string subUrl)
        {
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/"+ subUrl);
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            return await httpResponseMessage.Content.ReadAsStringAsync();

        }
    }
}