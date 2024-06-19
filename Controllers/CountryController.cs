using BasicWebApiFirstExam.Data;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Implementations;
using BasicWebApiFirstExam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApiFirstExam.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController( ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("CreateCountryAsync")]
        public async Task<JsonResult> CreateCountryAsync([FromBody] int id)
        {

            var country = await _countryService.CreateCountryAsync(id);

            return new JsonResult(country);

        }

        [HttpPost("UpdateCountryAsync")]
        public async Task<JsonResult> UpdateCountryAsync([FromBody] Country country)
        {

            var countries = await _countryService.UpdateCountryAsync(country);
            return new JsonResult(countries);
        }

        [HttpPost("DeleteCountryAsync")]
        public async Task<JsonResult> DeleteCountryAsync([FromBody] int id)
        {

            await _countryService.DeleteCountryAsync(id);
            return new JsonResult(true);
        }

        [HttpGet("GetCountries")]
        public async Task<JsonResult> GetCountries()
        {

            var result = await _countryService.GetCountries();
            return new JsonResult(result);
        }
    }
}
