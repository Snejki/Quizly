using MediatR;

namespace Quizly.Modules.Questions.Application.Queries;

public record GetQuestionListQuery() : IRequest<GetQuestionListResponseDto>;

public record GetQuestionListRequestDto();

public class GetQuestionListResponseDto
{
    public List<Item> Items { get; set; }

    public class Item
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
    }
}