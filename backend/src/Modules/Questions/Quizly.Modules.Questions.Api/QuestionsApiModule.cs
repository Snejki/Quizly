using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Questions.Infrastructure;
using Quizly.Shared.Abstractions.Modules;

namespace Quizly.Modules.Questions.Api;

// ReSharper disable once UnusedType.Global
public class QuestionsApiModule : IModule
{
    public void AddModule(IServiceCollection services)
    {
        services.AddQuestionsInfrastructure();
    }

    public void UseModule(WebApplication app)
    {
        app.UseQuestionsInfrastructure();
    }
}