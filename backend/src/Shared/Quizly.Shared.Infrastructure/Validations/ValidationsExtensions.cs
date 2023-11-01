using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Quizly.Shared.Infrastructure.Validations;

internal static class ValidationsExtensions
{
    internal static void AddCustomValidation(this IServiceCollection services, IList<Assembly> assemblies)
    {
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblies(assemblies);
    }
}