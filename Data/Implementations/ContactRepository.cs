using BasicWebApiFirstExam.Data.Extensions;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiFirstExam.Data.Implementations
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        public ContactRepository(CompanyDbContext context) : base(context)
        {

        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Contact> GetContactByContactName(string contactName)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.ContactName == contactName);
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await DbSet.Where(x => x.Id == id)
                               .Include(x => x.Company)
                               .Include(x => x.Country)
                               .FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetContactByCompanyIdAndCountryIdAsync(int companyId, int countryId)
        {
            return await DbSet.Where(x => x.CompanyId == companyId && x.CountryId == countryId)
                               .ToListAsync();
        }
    }
}
