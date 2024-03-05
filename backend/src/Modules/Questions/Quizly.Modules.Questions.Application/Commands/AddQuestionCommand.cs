using MediatR;
using Quizly.Modules.Questions.Domain;

namespace Quizly.Modules.Questions.Application.Commands;

public record AddQuestionCommand(AddQuestionRequestDto Dto) : IRequest<Unit>;

public class AddQuestionRequestDto
{
    public Guid CategoryId { get; set; }
    public QuestionType Type { get;  set; }
    public string QuestionText { get;  set; }
    public string ImagePath { get;  set; }
    public string AudioPath { get;  set; }
    public string VideoPath { get;  set; }
    public List<Answer> Answers { get; set; }

    public class Answer
    {
        public string Text { get; set; }
        public bool IsActive { get; set; }
    }
}