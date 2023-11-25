using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quizly.Modules.Users.Application.Services;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Modules.Users.Infrastructure.DAL;

public class UsersDatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public UsersDatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            if (env.IsDevelopment() is false)
            {
                return;
            }

            if (await dbContext.Users.AnyAsync(cancellationToken) is false)
            {
                var passwordService = scope.ServiceProvider.GetRequiredService<IPasswordService>();
                var clock = scope.ServiceProvider.GetRequiredService<IClock>();

                var users = new List<User>()
                {
                    new(new UserId(Guid.NewGuid()), new Login("TOMEK"), new Email("tomek@mail.com"),
                        new(passwordService.GeneratePasswordHash("TOMASZEK")), clock.Current),
                };

                dbContext.AddRange(users);
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}