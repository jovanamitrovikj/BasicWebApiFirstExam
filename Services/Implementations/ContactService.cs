using BasicWebApiFirstExam.Common;
using BasicWebApiFirstExam.Data.Implementations;
using BasicWebApiFirstExam.Data.Interfaces;
using BasicWebApiFirstExam.Domain;
using BasicWebApiFirstExam.Services.Interfaces;

namespace BasicWebApiFirstExam.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Contact> CreateContactAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            await _contactRepository.CreateAsync(contact);

            return contact;
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);

            if (contact == null)
            {
                throw new CompanyException("For contact don't have record in database ");

            }

            await _contactRepository.DeleteByIdAsync(contact);
        }

        public async Task<List<Contact>> GetContacts()
        {
            var allContacts =  await _contactRepository.GetAllContactsAsync();

            return allContacts;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            var contactItem = await _contactRepository.GetContactByIdAsync(contact.Id);

            if (contactItem == null)
            {
                throw new CompanyException("Not to have record for id  for contact ");
            }

            var contactName = await _contactRepository.GetContactByContactName(contact.ContactName);

            if (contactName != null && contact.Id != contactItem.Id)
            {
                throw new CompanyException("Contact with the same name already exist ");
            }

            contactItem.Id = contact.Id;
            contactItem.ContactName = contact.ContactName;
            contactItem.CompanyId = contact.CompanyId;
            contactItem.CountryId = contact.CountryId;

            await _contactRepository.UpdateAsync(contactItem);

            return contactItem;
        }

        public async Task<List<Contact>> FilterContact(int companyId, int countryId)
        {
            var contacts = await  _contactRepository.GetContactByCompanyIdAndCountryIdAsync(companyId, countryId);
            
            if(contacts == null || !contacts.Any())
            {
                throw new CompanyException("Not to have record   for contact ");
            }
            return contacts;

        }
    }
}
