using BasicWebApiFirstExam.Data.Extensions;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiFirstExam.Data.Implementations
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {

        public CompanyRepository(CompanyDbContext context) : base(context) 
        {
            
        }
        public async  Task<List<Company>> GetAllCompaniesAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Company> GetCompanyByCompanyName(string companyName)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CompanyName == companyName);
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
