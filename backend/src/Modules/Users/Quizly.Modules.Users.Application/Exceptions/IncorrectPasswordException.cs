using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public sealed class IncorrectPasswordException : QuizlyException
{
    public IncorrectPasswordException()
        : base("Incorrect login or password")
    {
    }
}