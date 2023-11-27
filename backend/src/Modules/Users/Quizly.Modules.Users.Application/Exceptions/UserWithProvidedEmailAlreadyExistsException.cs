using Quizly.Shared.Abstractions.Exceptions;

namespace Quizly.Modules.Users.Application.Exceptions;

public class UserWithProvidedEmailAlreadyExistsException : QuizlyException
{
    public UserWithProvidedEmailAlreadyExistsException(string email)
        : base($"User with email '{email}' already exists")
    {
    }
}