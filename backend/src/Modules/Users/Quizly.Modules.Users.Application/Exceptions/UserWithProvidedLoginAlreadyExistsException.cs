using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public class UserWithProvidedLoginAlreadyExistsException : QuizlyException
{
    public UserWithProvidedLoginAlreadyExistsException(string login)
        : base($"User with login '{login}' already exists")
    {
    }
}