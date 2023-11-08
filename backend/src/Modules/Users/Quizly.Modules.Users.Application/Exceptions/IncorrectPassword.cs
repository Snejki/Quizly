using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public sealed class IncorrectPassword : QuizlyException
{
    public IncorrectPassword() : base("Incorrect login or password")
    {
    }
}