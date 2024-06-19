

using BasicWebApiFirstExam.Controllers;
using BasicWebApiFirstExam.Data;
using BasicWebApiFirstExam.Data.Implementations;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Implementations;
using BasicWebApiFirstExam.Services.Interfaces;

namespace CompanyTestProject
{
    public class CompanyControllerTest
    {
        private CompanyDbContext context;

        private CompanyController  _companyController;

        private ICompanyService _companyService;
        
        private ICompanyRepository _companyRepository;

        [SetUp]
        public void Setup()
        {
            _companyRepository = new CompanyRepository(context);
            _companyService = new CompanyService(_companyRepository);
            _companyController = new CompanyController(_companyService);
        }

        [Test]
        public async Task CreateCompanyAsync()
        {
            var company = new Company
            {
                Id = 1,
                CompanyName = "ASPEKT"

            };
            var result = await _companyController.CreateCompanyAsync(company.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateCompanyAsync()
        {
            var company = new Company
            {
                Id = 1,
                CompanyName = "ASPEKT1"

            };
            var result = await _companyController.UpdateCompanyAsync(company);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task DeleteCompanyAsync()
        {
            var company = new Company
            {
                Id = 1,
                

            };
            var result = await _companyController.DeleteCompanyAsync(company.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetCompanies()
        {
           
            var result = await _companyController.GetCompanies();
            Assert.IsNotNull(result);
        }

    }
}