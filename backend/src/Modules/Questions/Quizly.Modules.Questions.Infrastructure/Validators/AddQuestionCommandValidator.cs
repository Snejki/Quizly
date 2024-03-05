using FluentValidation;
using Quizly.Modules.Questions.Application.Commands;

namespace Quizly.Modules.Questions.Infrastructure.Validators;

// ReSharper disable once UnusedType.Global
public class AddQuestionCommandValidator : AbstractValidator<AddQuestionCommand>
{
    public AddQuestionCommandValidator()
    {
        RuleFor(x => x.Dto.CategoryId).NotEmpty();
        RuleFor(x => x.Dto.Type).IsInEnum();
        RuleFor(x => x.Dto.QuestionText).NotEmpty();

        RuleFor(x => x.Dto.Answers)
            .Must(x => x.Count >= 4)
            .Must(x => x.Count(y => y.IsActive) == 1);

        //RuleForEach(x => x.Dto.Answers).
    }
}