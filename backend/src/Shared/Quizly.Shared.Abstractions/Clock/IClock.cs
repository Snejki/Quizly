namespace Quizly.Shared.Abstractions.Clock;

public interface IClock
{
    DateTime Current { get; }
}