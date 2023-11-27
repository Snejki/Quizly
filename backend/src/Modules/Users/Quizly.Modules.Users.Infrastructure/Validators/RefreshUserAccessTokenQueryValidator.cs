using FluentValidation;
using Quizly.Modules.Users.Application.Queries;

namespace Quizly.Modules.Users.Infrastructure.Validators;

// ReSharper disable once UnusedType.Global
public sealed class RefreshUserAccessTokenQueryValidator : AbstractValidator<RefreshUserAccessTokenQuery>
{
    public RefreshUserAccessTokenQueryValidator()
    {
        RuleFor(x => x.AccessToken).NotEmpty();
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}