using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

    public DbSet<Contact>? Contacts { get; set; }
}
