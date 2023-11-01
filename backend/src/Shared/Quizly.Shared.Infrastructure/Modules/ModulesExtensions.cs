using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Shared.Abstractions.Modules;

namespace Quizly.Shared.Infrastructure.Modules;

public static class ModulesExtensions
{
    internal static void AddModules(this IServiceCollection services, IList<IModule> modules)
    {
        foreach (var module in modules)
        {
            module.AddModule(services);
        }
    }

    internal static void UseModules(this WebApplication app, IList<IModule> modules)
    {
        foreach (var module in modules)
        {
            module.UseModule(app);
        }
    }
}