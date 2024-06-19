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
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;

        public ContactController( IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("CreateContactAsync")]
        public async Task<JsonResult> CreateContactAsync([FromBody] int id)
        {

            var contact = await _contactService.CreateContactAsync(id);

            return new JsonResult(contact);

        }

        [HttpPost("UpdateContactAsync")]
        public async Task<JsonResult> UpdateContactAsync([FromBody] Contact contact)
        {

            var contacts = await _contactService.UpdateContactAsync(contact);
            return new JsonResult(contacts);
        }

        [HttpPost("DeleteContactAsync")]
        public async Task<JsonResult> DeleteContactAsync([FromBody] int id)
        {

            await _contactService.DeleteContactAsync(id);
            return new JsonResult(true);
        }

        [HttpGet("GetContacts")]
        public async Task<JsonResult> GetContacts()
        {

            var result = await _contactService.GetContacts();
            return new JsonResult(result);
        }

        [HttpGet("FilterContact")]
        public async Task<JsonResult> FilterContact([FromBody] int companyId, int countryId)
        {

            var result = await _contactService.FilterContact(companyId, countryId);
            return new JsonResult(result);
        }
    }
}
