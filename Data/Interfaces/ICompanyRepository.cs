using BasicWebApiFirstExam.Data.Extensions;
using BasicWebApiFirstExam.Domain;

namespace BasicWebApiFirstExam.Data.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<Company> GetCompanyByIdAsync(int id);

        Task<List<Company>> GetAllCompaniesAsync();

        Task<Company> GetCompanyByCompanyName(string companyName);
    }
}
