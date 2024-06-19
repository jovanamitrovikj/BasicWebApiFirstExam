using BasicWebApiFirstExam.Common;
using BasicWebApiFirstExam.Data;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Implementations;
using BasicWebApiFirstExam.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApiFirstExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController( ICompanyService companyService)
        {
            
            _companyService = companyService;
        }

        [HttpPost("CreateCompanyAsync")]
        public async Task<JsonResult> CreateCompanyAsync([FromBody] int id)
        {           

            var company = await _companyService.CreateCompanyAsync(id);

            return new JsonResult(company);

        }
        
        [HttpPost("UpdateCompanyAsync")]
        public async Task<JsonResult> UpdateCompanyAsync([FromBody] Company company)
        {

             var companies = await _companyService.UpdateCompanyAsync(company);
             return new JsonResult(companies);
        }

        [HttpPost("DeleteCompanyAsync")]
        public async Task<JsonResult> DeleteCompanyAsync([FromBody] int id)
        {

             await _companyService.DeleteCompanyAsync(id);
             return new JsonResult(true);
        }

        [HttpGet("GetCompanies")]
        public async Task<JsonResult> GetCompanies()
        {

            var result =  await _companyService.GetCompanies();
            return new JsonResult(result);
        }
    }

}

    

