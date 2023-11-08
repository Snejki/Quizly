using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Quizly.Shared.Infrastructure.Database;

public static class DatabaseExtensions
{
    public static void AddCustomDbContext<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        services.AddDbContext<TContext>(opts => opts.UseInMemoryDatabase("TEST_NAME"));
    }
}