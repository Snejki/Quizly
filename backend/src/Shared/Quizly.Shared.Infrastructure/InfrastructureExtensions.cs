using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quizly.Shared.Abstractions.Modules;
using Quizly.Shared.Infrastructure.Clock;
using Quizly.Shared.Infrastructure.Endpoints;
using Quizly.Shared.Infrastructure.Logger;
using Quizly.Shared.Infrastructure.Mediatr;
using Quizly.Shared.Infrastructure.Modules;

namespace Quizly.Shared.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddModularInfrastructure(this WebApplicationBuilder builder, IList<Assembly> assemblies, IList<IModule> modules)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMediatr(assemblies);
        builder.Services.AddModules(modules);
        builder.Services.AddClock();
        
        builder.Host.AddCustomLogger();
    }

    public static void UseModularInfrastructure(this WebApplication app, IList<Assembly> assemblies, IList<IModule> modules)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseModules(modules);
        app.UseEndpoints(assemblies.ToArray());
        app.UseHttpsRedirection();
    }
}