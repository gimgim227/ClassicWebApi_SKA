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
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/all");
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
        }
        public async Task<CountryInfo> GetMapByCountryName(string country)
        {
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/name/"+ country);
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data).FirstOrDefault();
        }
        public async Task<List<string>> GetCountryNamesBySubRegion(string subRegion)
        {
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/subregion/" + subRegion);
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var countryInfos = JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
            return countryInfos?.Select(x => x.CountryName.Common).ToList();
        }
    }
}