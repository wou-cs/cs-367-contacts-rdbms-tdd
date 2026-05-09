using ContactList.Models;

namespace ContactList.Tests.Unit.Fakes;

public class ApplicationContextFakeBuilder : IDisposable
{
    private readonly ApplicationContextFake _ctx = new();

    public ApplicationContextFakeBuilder WithContact(string name, string category = "Work")
    {
        _ctx.Contacts!.Add(new Contact { Name = name, Category = category });
        return this;
    }

    public ApplicationContextFake Build()
    {
        _ctx.SaveChanges();
        return _ctx;
    }

    public void Dispose() => _ctx.Dispose();
}