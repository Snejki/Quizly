using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public class UserWithProvidedEmailAlreadyExists : QuizlyException
{
    public UserWithProvidedEmailAlreadyExists(string email) : base($"User with email '{email}' already exists")
    {
    }
}