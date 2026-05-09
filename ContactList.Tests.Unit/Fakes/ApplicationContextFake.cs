using ContactList.Database;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Tests.Unit.Fakes;

public class ApplicationContextFake : ApplicationContext
{
    public ApplicationContextFake() : base(
        new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase($"ContactsTest-{Guid.NewGuid()}")
            .Options) { }
}
