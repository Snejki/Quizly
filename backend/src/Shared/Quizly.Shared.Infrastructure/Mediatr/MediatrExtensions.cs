using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quizly.Shared.Infrastructure.Mediatr.PipelineBehaviors;

namespace Quizly.Shared.Infrastructure.Mediatr;

public static class MediatrExtensions
{
    internal static void AddCustomMediatr(this IServiceCollection services, IList<Assembly> assembiles)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembiles.ToArray()));

        services.AddPipelineBehaviors();
    }

    private static void AddPipelineBehaviors(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthValidationBehavior<,>));
    }
}