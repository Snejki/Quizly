using FluentValidation;
using Quizly.Modules.Users.Application.Commands;

namespace Quizly.Modules.Users.Infrastructure.Validators;

// ReSharper disable once UnusedType.Global
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Login).MinimumLength(3);
    }
}