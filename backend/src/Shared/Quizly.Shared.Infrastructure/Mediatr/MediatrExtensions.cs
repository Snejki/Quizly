using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Quizly.Shared.Infrastructure.Mediatr;

public static class MediatrExtensions
{
    internal static void AddMediatr(this IServiceCollection services, IList<Assembly> assembiles)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembiles.ToArray()));
    }
}