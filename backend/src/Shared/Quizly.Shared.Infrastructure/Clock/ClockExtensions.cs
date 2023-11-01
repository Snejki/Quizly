using Microsoft.Extensions.DependencyInjection;
using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Shared.Infrastructure.Clock;

internal static class ClockExtensions
{
    internal static void AddClock(this IServiceCollection services)
    {
        services.AddSingleton<IClock, Clock>();
    }
}