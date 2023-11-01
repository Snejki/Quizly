using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Users.Infrastructure;
using Quizly.Shared.Abstractions.Modules;

namespace Quizly.Modules.Users.Api;

// ReSharper disable once UnusedType.Global
public class UsersApiModule : IModule
{
    public void AddModule(IServiceCollection services)
    {
        services.AddUsersInfrastructure();
    }

    public void UseModule(WebApplication app)
    {
        app.UseUsersInfrastructure();
    }
}