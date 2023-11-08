using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public class UserWithProvidedLoginAlreadyExists : QuizlyException
{
    public UserWithProvidedLoginAlreadyExists(string login) : base($"User with login '{login}' already exists")
    {
    }
}