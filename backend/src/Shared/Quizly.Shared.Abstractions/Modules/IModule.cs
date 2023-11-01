using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Quizly.Shared.Abstractions.Modules;

public interface IModule
{
    public void AddModule(IServiceCollection services);
    public void UseModule(WebApplication app);
}