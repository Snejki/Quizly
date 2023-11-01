namespace Quizly.Shared.Abstractions.Exceptions;

public class QuizlyException : Exception
{
    public QuizlyException(string message) : base(message)
    {
        
    }
}