namespace Quizly.Shared.Abstractions.Exceptions;

public class QuizlyException : Exception
{
    protected QuizlyException(string message)
        : base(message)
    {
    }
}