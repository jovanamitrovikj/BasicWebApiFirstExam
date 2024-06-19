using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Models;

namespace BasicWebApiFirstExam.Services.Interfaces
{
    public interface ICompanyService
    {

        Task<Company> CreateCompanyAsync(int id);

        Task<Company>  UpdateCompanyAsync (Company  company);

        Task DeleteCompanyAsync(int id);

        Task<List<Company>> GetCompanies();
    }
}
