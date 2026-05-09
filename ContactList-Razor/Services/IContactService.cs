using ContactList.Models;

namespace ContactList.Services;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task AddAsync(Contact contact);
    Task DeleteAsync(int id);
    Task<IEnumerable<Contact>> SearchByNameAsync(string query);
}