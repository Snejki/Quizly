using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public sealed class UserWithProvidedLoginNotFoundException : QuizlyException
{
    public UserWithProvidedLoginNotFoundException()
        : base("Incorrect login or password")
    {
    }
}