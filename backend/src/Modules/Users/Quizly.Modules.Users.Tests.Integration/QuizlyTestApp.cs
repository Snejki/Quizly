using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Quizly.Modules.Users.Tests.Infrastructure;

internal class QuizlyTestApp : WebApplicationFactory<Program>
{
    public HttpClient Client { get; }

    public QuizlyTestApp(Action<IServiceCollection>? services = null)
    {
        Client = WithWebHostBuilder(builder =>
        {
            if (services is not null)
            {
                builder.ConfigureServices(services);
            }

            builder.UseEnvironment("test");
        }).CreateClient();
    }
}