using MediatR;
using Microsoft.Extensions.Logging;
using Quizly.Modules.Questions.Application.Commands;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Domain.Repositories;

namespace Quizly.Modules.Questions.Infrastructure.Commands;

// ReSharper disable once UnusedType.Global
public sealed class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, Unit>
{
    private readonly ILogger<AddQuestionCommandHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IQuestionRepository _questionRepository;

    public AddQuestionCommandHandler(
        ICategoryRepository categoryRepository,
        ILogger<AddQuestionCommandHandler> logger,
        IQuestionRepository questionRepository)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
        _questionRepository = questionRepository;
    }

    public async Task<Unit> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(new CategoryId(request.Dto.CategoryId), cancellationToken);
        if (category is null)
        {
            throw new Exception();
        }

        var answers = request.Dto.Answers.Select(x => new Answer(x.Text, x.IsActive)).ToList();
        var question = Question.CreateTextQuestion(
            new QuestionId(Guid.NewGuid()),
            category.Id,
            request.Dto.QuestionText,
            answers);

        await _questionRepository.Add(question, cancellationToken);
        return Unit.Value;
    }
}