using BasicWebApiFirstExam.Data.Extensions;
using BasicWebApiFirstExam.Domain;

namespace BasicWebApiFirstExam.Data.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {

        Task<Country> GetCountryByIdAsync(int id);

        Task<List<Country>> GetAllCountriesAsync();

        Task<Country> GetCountryByCountryName(string countryName);
    }
}
