using BasicWebApiFirstExam.Data.Extensions;
using BasicWebApiFirstExam.Domain;

namespace BasicWebApiFirstExam.Data.Interfaces
{
    public interface IContactRepository :  IGenericRepository<Contact>
    {

        Task<Contact> GetContactByIdAsync(int id);

        Task<List<Contact>> GetAllContactsAsync();

        Task<Contact> GetContactByContactName(string contactName);

        Task<List<Contact>> GetContactByCompanyIdAndCountryIdAsync(int companyId, int countryId);

    }
}
