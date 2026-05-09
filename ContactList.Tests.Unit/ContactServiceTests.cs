using ContactList.Services;
using ContactList.Tests.Unit.Fakes;

namespace ContactList.Tests.Unit;

public class ContactServiceTests : IDisposable
{
    private readonly ApplicationContextFakeBuilder _ctxBuilder = new();

    [Fact]
    public async Task GetAllAsync_EmptyDatabase_ReturnsEmpty()
    {
        // Arrange
        var ctx = _ctxBuilder.Build();
        var sut = new ContactService(ctx);

        // Act 
        var actual = await sut.GetAllAsync();

        // Assert 
        Assert.Empty(actual);
    }

    [Fact]
    public async Task SearchByNameAsync_EmptyDatabase_ReturnsEmpty()
    {
        // Arrange
        var ctx = _ctxBuilder.Build();
        var sut = new ContactService(ctx);

        // Act 
        var actual = await sut.SearchByNameAsync("Alice");

        // Assert 
        Assert.Empty(actual);
    }

    [Fact]

    public async Task SearchByNameAsync_OneMatchingContact_ReturnsIt()
    {
        // Arrange
        var ctx = _ctxBuilder.WithContact("Alice").Build();
        var sut = new ContactService(ctx);

        // Act 
        var actual = await sut.SearchByNameAsync("Alice");

        // Assert 
        Assert.Single(actual);
    }

    [Fact]
    public async Task SearchByNameAsync_NoMatches_ReturnsEmpty()
    {
        // Arrange
        var ctx = _ctxBuilder.WithContact("Alice").Build();
        var sut = new ContactService(ctx);

        // Act 
        var actual = await sut.SearchByNameAsync("Bob");

        // Assert 
        Assert.Empty(actual);
    }

    public void Dispose() => _ctxBuilder.Dispose();
}