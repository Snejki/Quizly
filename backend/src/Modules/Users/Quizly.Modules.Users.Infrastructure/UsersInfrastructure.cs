using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.DAL;
using Quizly.Modules.Users.Infrastructure.Repositories;
using Quizly.Modules.Users.Infrastructure.Services;
using Quizly.Shared.Infrastructure.Database;

namespace Quizly.Modules.Users.Infrastructure;

public static class UsersInfrastructure
{
    public static void AddUsersInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPasswordService, PasswordService>();
        services.AddTransient<ITokenService, TokenService>();

        services.AddCustomDbContext<UsersDbContext>();

        services.AddHostedService<UsersDatabaseInitializer>();
    }
    
    public static void UseUsersInfrastructure(this WebApplication app)
    {
        
    }
}