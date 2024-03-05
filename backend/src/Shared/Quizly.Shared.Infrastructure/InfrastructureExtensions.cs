using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quizly.Shared.Abstractions.Auth;
using Quizly.Shared.Abstractions.Modules;
using Quizly.Shared.Infrastructure.Auth;
using Quizly.Shared.Infrastructure.Clock;
using Quizly.Shared.Infrastructure.Endpoints;
using Quizly.Shared.Infrastructure.Exceptions;
using Quizly.Shared.Infrastructure.Logger;
using Quizly.Shared.Infrastructure.Mediatr;
using Quizly.Shared.Infrastructure.Modules;
using Quizly.Shared.Infrastructure.Repositories;
using Quizly.Shared.Infrastructure.Validations;

namespace Quizly.Shared.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddModularInfrastructure(this WebApplicationBuilder builder, IConfiguration configuration, IList<Assembly> assemblies, IList<IModule> modules)
    {
        builder.Services.AddCustomAuth(configuration);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCustomMediatr(assemblies);
        builder.Services.AddModules(modules);
        builder.Services.AddClock();
        builder.Services.AddCustomExceptionHandling();
        builder.Services.AddCustomValidation(assemblies);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAll",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
        builder.Host.AddCustomLogger();

        builder.Services.AddScoped(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));

        builder.Services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Path));
    }

    public static void UseModularInfrastructure(this WebApplication app, IList<Assembly> assemblies, IList<IModule> modules)
    {
        app.UseCors("AllowAll");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomExceptionHandling();
        app.UseModules(modules);
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(assemblies.ToArray());
        app.UseHttpsRedirection();
    }
}