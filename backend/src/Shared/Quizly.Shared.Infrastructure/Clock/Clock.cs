using Quizly.Shared.Abstractions.Clock;

namespace Quizly.Shared.Infrastructure.Clock;

internal class Clock : IClock
{
    public DateTime Current => DateTime.UtcNow;
}