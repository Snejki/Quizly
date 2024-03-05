using MediatR;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Infrastructure.DAL;
using Quizly.Modules.Questions.Infrastructure.Specifications;
using Quizly.Shared.Infrastructure.Repositories;

namespace Quizly.Modules.Questions.Infrastructure.Queries;

// ReSharper disable once UnusedType.Global
public sealed class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, GetQuestionListResponseDto>
{
    private readonly IReadOnlyRepository<QuestionsDbContext, Question> _questionReadonlyRepository;

    public GetQuestionListQueryHandler(IReadOnlyRepository<QuestionsDbContext, Question> questionReadonlyRepository)
    {
        _questionReadonlyRepository = questionReadonlyRepository;
    }

    public async Task<GetQuestionListResponseDto> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionReadonlyRepository.List(new GetQuestionListSpecification(), cancellationToken);
        return new GetQuestionListResponseDto()
        {
            Items = questions,
        };
    }
}