using BasicWebApiFirstExam.Controllers;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Data;
using BasicWebApiFirstExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebApiFirstExam.Data.Implementations;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Implementations;

namespace CompanyTestProject
{
    public class CountryControllerTest
    {
        private CompanyDbContext context;

        private CountryController _countryController;

        private ICountryService _countryService;

        private ICountryRepository _countryRepository;

        [SetUp]
        public void Setup()
        {
            _countryRepository = new CountryRepository(context);
            _countryService = new CountryService(_countryRepository);
            _countryController = new CountryController(_countryService);
        }

        [Test]
        public async Task CreateCountryAsync()
        {
            var country = new Country
            {
                Id = 1,
                CountryName = "Macedonia"

            };
            var result = await _countryController.CreateCountryAsync(country.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateCountryAsync()
        {
            var country = new Country
            {
                Id = 1,
                CountryName = "NorthMacedonia"

            };
            var result = await _countryController.UpdateCountryAsync(country);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task DeleteCountryAsync()
        {
            var country = new Country
            {
                Id = 1,


            };
            var result = await _countryController.DeleteCountryAsync(country.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetCountries()
        {

            var result = await _countryController.GetCountries();
            Assert.IsNotNull(result);
        }

    }
}
