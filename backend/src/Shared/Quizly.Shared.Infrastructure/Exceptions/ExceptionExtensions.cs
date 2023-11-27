using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Quizly.Shared.Infrastructure.Exceptions;

internal static class ExceptionExtensions
{
    public static IServiceCollection AddCustomExceptionHandling(this IServiceCollection services) =>
        services.AddScoped<ExceptionHandlingMiddleware>();

    public static IApplicationBuilder UseCustomExceptionHandling(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionHandlingMiddleware>();
}