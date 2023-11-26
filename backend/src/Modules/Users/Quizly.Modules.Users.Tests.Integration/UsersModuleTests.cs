using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Users.Infrastructure.DAL;
using Xunit;

namespace Quizly.Modules.Users.Tests.Infrastructure;

public abstract class UsersModuleTests : IAsyncLifetime
{
    private QuizlyTestApp _testApi = null;

    protected HttpClient Client => _testApi.Client;

    protected UsersDbContext DbContext { get; private set; }

    protected virtual Action<IServiceCollection>? ConfigureServices => null;

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
        DbContext = new(
            new DbContextOptionsBuilder<UsersDbContext>()
                .UseInMemoryDatabase("TEST_NAME")
                .Options)
            ;
        _testApi = new QuizlyTestApp(ConfigureServices);
    }

    public async Task DisposeAsync()
    {
        await _testApi.DisposeAsync();
        await DbContext.DisposeAsync();
    }
}