namespace Quizly.Modules.Questions.Domain.Entities;

public class Question
{
    public QuestionId Id { get; private set; }
    public string QuestionText { get; private set; }
    public string ImagePath { get; private set; }
    public string AudioPath { get; private set; }
    public string VideoPath { get; private set; }
    public QuestionType Type { get; private set; }

    public bool IsAccepted { get; private set; }
    public bool IsActive { get; private set; }

    public virtual Category Category { get; private set; }
    public virtual List<Answer> Answers { get; private set; }
}
