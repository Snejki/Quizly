using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public sealed class UserWithProvidedLoginNotFound : QuizlyException
{
    public UserWithProvidedLoginNotFound() : base("Incorrect login or password")
    {
    }
}