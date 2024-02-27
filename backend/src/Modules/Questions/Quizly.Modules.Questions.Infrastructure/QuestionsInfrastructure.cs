using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Questions.Domain.Repositories;
using Quizly.Modules.Questions.Infrastructure.DAL;
using Quizly.Modules.Questions.Infrastructure.Repositories;
using Quizly.Shared.Infrastructure.Database;

namespace Quizly.Modules.Questions.Infrastructure;

public static class QuestionsInfrastructure
{
    public static void AddQuestionsInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<ICategoryReadonlyRepository, CategoryReadOnlyRepository>();
        services.AddCustomDbContext<QuestionsDbContext>();
        services.AddHostedService<QuestionsDatabaseInitializer>();
    }

    public static void UseQuestionsInfrastructure(this WebApplication app)
    {
    }
}