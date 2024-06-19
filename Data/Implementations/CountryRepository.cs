using BasicWebApiFirstExam.Data.Extensions;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiFirstExam.Data.Implementations
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {

        public CountryRepository(CompanyDbContext context) : base(context)
        {

        }
        public Task<List<Country>> GetAllCountriesAsync()
        {
            return DbSet.ToListAsync();
        }

        public async Task<Country> GetCountryByCountryName(string countryName)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CountryName == countryName);
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
