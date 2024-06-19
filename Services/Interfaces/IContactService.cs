using BasicWebApiFirstExam.Domain;

namespace BasicWebApiFirstExam.Services.Interfaces
{
    public interface IContactService
    {

        Task<Contact> CreateContactAsync(int id);

        Task<Contact> UpdateContactAsync(Contact country);

        Task DeleteContactAsync(int id);

        Task<List<Contact>> GetContacts();

        Task<List<Contact>> FilterContact( int companyId, int countryId);
    }
}
