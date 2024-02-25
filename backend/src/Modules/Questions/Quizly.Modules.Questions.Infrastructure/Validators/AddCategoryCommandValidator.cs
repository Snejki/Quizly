using FluentValidation;
using Quizly.Modules.Questions.Application.Commands;

namespace Quizly.Modules.Questions.Infrastructure.Validators;

public sealed class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.ImagePath).NotEmpty();
    }
}
