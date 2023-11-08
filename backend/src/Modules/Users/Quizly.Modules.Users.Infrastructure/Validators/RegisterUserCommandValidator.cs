using FluentValidation;
using Quizly.Modules.Users.Application.Commands;

namespace Quizly.Modules.Users.Infrastructure.Validators;

// ReSharper disable once UnusedType.Global
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Login).MinimumLength(8).MaximumLength(24);
        RuleFor(x => x.Password).MinimumLength(8);
        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
    }
}