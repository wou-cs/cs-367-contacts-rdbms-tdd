using ContactList.Database;
using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Services;

public class ContactService : IContactService
{
    private readonly ApplicationContext _context;
    public ContactService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync() 
        => await _context.Contacts!.ToArrayAsync();

    public async Task<Contact?> GetByIdAsync(int id)
        => await _context.Contacts!.FirstOrDefaultAsync(c => c.Id == id);
    public async Task AddAsync(Contact contact)
    {
        _context.Contacts!.Add(contact);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var contact = await _context.Contacts!.FirstOrDefaultAsync(c => c.Id == id);
        if (contact is not null)
        {
            _context.Contacts!.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}