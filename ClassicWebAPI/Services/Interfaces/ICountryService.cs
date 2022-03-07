using ClassicWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassicWebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryInfo>> GetAll();
        Task<CountryInfo> GetCountry(string country);
        Task<IEnumerable<CountryInfo>> GetRegionCountry(string subRegion);
    }
}