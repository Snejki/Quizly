using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Modules.Quizes.Infrastructure;
using Quizly.Shared.Abstractions.Modules;

namespace Quizly.Modules.Quizes.Api;

// ReSharper disable once UnusedType.Global
public class QuizesModule : IModule
{
    public void AddModule(IServiceCollection services)
    {
        services.AddSignalR();
        services.AddSingleton<GameLobby>();
    }

    public void UseModule(WebApplication app)
    {
        app.MapHub<QuizHub>("game");
    }
}