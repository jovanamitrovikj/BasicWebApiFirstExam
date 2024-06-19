using BasicWebApiFirstExam.Common;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Models;
using BasicWebApiFirstExam.Services.Interfaces;


namespace BasicWebApiFirstExam.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<Company> CreateCompanyAsync(int id)
        {
            
            var company =  await _companyRepository.GetByIdAsync(id);

            await _companyRepository.CreateAsync(company);

            return company;

        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            var companyItem = await _companyRepository.GetCompanyByIdAsync(company.Id);

            if(companyItem == null)
            {
                throw new CompanyException("Not to have record for id  for company ");
            }

            var companyName = await _companyRepository.GetCompanyByCompanyName(company.CompanyName);

            if (companyName != null && company.Id != companyItem.Id)
            {
                throw new CompanyException("Company with the same name already exist ");
            }

            companyItem.Id = company.Id;
            companyItem.CompanyName = company.CompanyName;

            await  _companyRepository.UpdateAsync(companyItem);

            return companyItem;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);

            if(company == null )
            {
                throw new CompanyException("For company don't have record in database ");

            }

            await _companyRepository.DeleteByIdAsync(company);
        }


        public async Task<List<Company>> GetCompanies()
        {
            var allCompanies = await _companyRepository.GetAllCompaniesAsync();

            return allCompanies;
        }
    }
}
