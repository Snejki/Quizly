using Ardalis.Specification;
using Quizly.Modules.Questions.Application.Queries;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.Specifications;

public sealed class GetQuestionListSpecification : Specification<Question, GetQuestionListResponseDto.Item>
{
    public GetQuestionListSpecification()
    {
        Query.Select(x => new GetQuestionListResponseDto.Item
        {
            QuestionId = x.Id.Id,
            QuestionText = x.QuestionText,
        });
    }
}