using BasicWebApiFirstExam.Common;
using BasicWebApiFirstExam.Data.Implementations;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicWebApiFirstExam.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<Country> CreateCountryAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            await _countryRepository.CreateAsync(country);

            return country;
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            var countryItem = await _countryRepository.GetCountryByIdAsync(country.Id);

            if (countryItem == null)
            {
                throw new CompanyException("Not to have record for id  for country ");
            }

            var countryName = await _countryRepository.GetCountryByCountryName(country.CountryName);

            if (countryName != null && country.Id != countryItem.Id)
            {
                throw new CompanyException("Country with the same name already exist ");
            }

            countryItem.Id = country.Id;
            countryItem.CountryName = country.CountryName;

            await _countryRepository.UpdateAsync(countryItem);

            return countryItem;
        }

        public async Task DeleteCountryAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
            {
                throw new CompanyException("For country don't have record in database ");

            }

            await _countryRepository.DeleteByIdAsync(country);
        }

        public  async Task<List<Country>> GetCountries()
        {
            var allCountries =  await _countryRepository.GetAllCountriesAsync();

            return allCountries;
        }
    }
}
