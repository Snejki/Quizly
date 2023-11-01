using Microsoft.Extensions.Hosting;
using Serilog;

namespace Quizly.Shared.Infrastructure.Logger;

internal static class LoggerExtensions
{
    internal static void AddCustomLogger(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((ctx, configuration) =>
        {
            configuration.ReadFrom.Configuration(ctx.Configuration);
        });
    }
}