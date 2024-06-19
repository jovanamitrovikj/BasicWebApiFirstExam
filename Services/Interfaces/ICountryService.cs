using BasicWebApiFirstExam.Domain;

namespace BasicWebApiFirstExam.Services.Interfaces
{
    public interface ICountryService
    {
        Task<Country> CreateCountryAsync(int id);

        Task<Country> UpdateCountryAsync(Country country);

        Task DeleteCountryAsync(int id);

        Task<List<Country>> GetCountries();
    }
}
