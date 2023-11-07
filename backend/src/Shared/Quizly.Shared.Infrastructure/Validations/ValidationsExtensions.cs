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

        FluentValidation.ValidatorOptions.Global.PropertyNameResolver = (type, memberInfo, expression) =>
        {
            var propertyName = memberInfo.Name;
            return Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
        };
    }
}