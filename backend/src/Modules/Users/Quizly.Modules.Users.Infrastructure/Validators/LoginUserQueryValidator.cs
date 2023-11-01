using FluentValidation;
using Quizly.Modules.Users.Application.Queries;

namespace Quizly.Modules.Users.Infrastructure.Validators;

public sealed class LoginUserQueryValidator : AbstractValidator<LoginUserQuery>
{
    public LoginUserQueryValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}