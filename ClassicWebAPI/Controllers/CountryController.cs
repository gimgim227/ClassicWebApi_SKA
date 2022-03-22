using ClassicWebAPI.Models;
using ClassicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicWebAPI.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return Ok("Welcome to ClassicWebAPI.");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return new JsonResult(await _countryService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Map(string country)
        {
            var countryInfo = await _countryService.GetMapByCountryName(country);
            var googleMapUrl = countryInfo.Map.GoogleMap;

            return Redirect(googleMapUrl);
        }

        [HttpPost]
        public async Task<IActionResult> GetCountryBySubRegion([FromBody] SubRegionRequest request)
        {
            var countriesNames = await _countryService.GetCountryNamesBySubRegion(request.SubRegion);
            if (countriesNames == null)
            {
                return Ok("Country Not Found");
            }

            return Ok(new GetCountryBySubRegionResponse
            {
                SubRegion = request.SubRegion,
                Countries = countriesNames
            });
        }
    }
}