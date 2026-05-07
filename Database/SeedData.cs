using ContactList.Models;

namespace ContactList.Database;

public static class SeedData
{
    public static void Seed(ApplicationContext context)
    {
        if (context.Contacts!.Any())
        {
            return;
        }

        context.Contacts!.AddRange(
            new Contact
            {
                Name = "Alice Smith",
                Email = "alice@example.com",
                Phone = "503-555-0101",
                Category = "Work",
                Notes = "Project manager"
            },
            new Contact
            {
                Name = "Bob Jones",
                Email = "bob@example.com",
                Phone = "503-555-0102",
                Category = "Friend"
            },
            new Contact
            {
                Name = "Carol White",
                Email = "carol@example.com",
                Phone = "503-555-0103",
                Category = "Family",
                Notes = "Sister"
            });

        context.SaveChanges();
    }
}
