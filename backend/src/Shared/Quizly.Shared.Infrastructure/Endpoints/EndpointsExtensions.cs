using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Quizly.Shared.Abstractions.Endpoints;

namespace Quizly.Shared.Infrastructure.Endpoints;

public static class EndpointsExtensions
{
    internal static void UseEndpoints(this WebApplication app, params Assembly[] assemblies)
    {
        if (assemblies == null || assemblies.Length == 0)
        {
            throw new Exception();
        }

        var endpointModules = LoadEndpoints(assemblies.ToList());

        foreach (var endpointModule in endpointModules)
        {
            endpointModule.UseEndpoints(app);
        }
    }

    private static IList<IEndpoint> LoadEndpoints(IEnumerable<Assembly> assemblies)
        => assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IEndpoint>()
            .ToList();
}