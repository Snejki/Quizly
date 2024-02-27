using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.DAL;

public class QuestionsDatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<QuestionsDbContext>();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            if (!env.IsDevelopment())
            {
                return;
            }

            if (!await dbContext.Categories.AnyAsync(cancellationToken))
            {
                await dbContext.AddRangeAsync(_categories, cancellationToken);
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private readonly List<Category> _categories = new()
    {
        new Category(new CategoryId(Guid.NewGuid()), "Friends", "Old sitcom", "PATH"),
        new Category(new CategoryId(Guid.NewGuid()), "Movies", "Movies category", "PATH"),
        new Category(new CategoryId(Guid.NewGuid()), "Computers", "Computers", "PATH"),
    };

    public QuestionsDatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}