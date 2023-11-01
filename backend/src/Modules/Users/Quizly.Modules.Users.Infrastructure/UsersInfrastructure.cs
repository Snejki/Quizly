﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.Repositories;

namespace Quizly.Modules.Users.Infrastructure;

public static class UsersInfrastructure
{
    public static void AddUsersInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }
    
    public static void UseUsersInfrastructure(this WebApplication app)
    {
        
    }
}