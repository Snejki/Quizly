using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Quizly.Shared.Tests.Integration;

public class ModuleTests<T>  : IAsyncLifetime where T : DbContext
{
    private QuizlyTestApp _testApi = null;

    protected HttpClient Client => _testApi.Client;

    protected T DbContext { get; private set; }

    protected IServiceProvider ServiceProvider => _testApi.Services;

    protected virtual Action<IServiceCollection>? ConfigureServices => null;

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
        DbContext = (T)Activator.CreateInstance(typeof(T),
            new DbContextOptionsBuilder<T>().UseInMemoryDatabase("TEST_NAME").Options)!;
        _testApi = new QuizlyTestApp(ConfigureServices);
    }

    public async Task DisposeAsync()
    {
        await _testApi.DisposeAsync();
        await DbContext.DisposeAsync();
    }
}