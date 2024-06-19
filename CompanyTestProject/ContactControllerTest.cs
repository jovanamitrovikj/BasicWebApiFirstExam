using BasicWebApiFirstExam.Controllers;
using BasicWebApiFirstExam.Data.Implementations;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Data;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Implementations;
using BasicWebApiFirstExam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject
{
    public class ContactControllerTest
    {
        private CompanyDbContext context;

        private ContactController _contactController;

        private IContactService _contactService;

        private IContactRepository _contactRepository;

        [SetUp]
        public void Setup()
        {
            _contactRepository = new ContactRepository(context);
            _contactService = new ContactService(_contactRepository);
            _contactController = new ContactController(_contactService);
        }

        [Test]
        public async Task CreateContactAsync()
        {
            var contact = new Contact
            {
                Id = 1,
                ContactName = "LinkedIn",
                CompanyId = 1,
                CountryId = 1

            };
            var result = await _contactController.CreateContactAsync(contact.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task UpdateCountryAsync()
        {
            var contact = new Contact
            {
                Id = 1,
                ContactName = "NorthMacedonia",
                CompanyId = 1,
                CountryId = 1

            };
            var result = await _contactController.UpdateContactAsync(contact);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task DeleteCountryAsync()
        {
            var contact = new Contact
            {
                Id = 1,


            };
            var result = await _contactController.DeleteContactAsync(contact.Id);
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GetContacts()
        {

            var result = await _contactController.GetContacts();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task FilterContact()
        {

            var contact = new Contact
            {
                Id = 1,
                ContactName = "LinkedIn",
                CompanyId = 1,
                CountryId = 1

            };

            var result = await _contactController.FilterContact(contact.CompanyId, contact.CountryId);
            Assert.IsNotNull(result);
        }


    }
}
