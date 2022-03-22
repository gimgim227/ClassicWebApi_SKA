using ClassicWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassicWebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryInfo>> GetAll();
        Task<CountryInfo> GetMapByCountryName(string country);
        Task<List<string>> GetCountryNamesBySubRegion(string subRegion);
    }
}