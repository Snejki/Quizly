namespace Quizly.Modules.Questions.Domain.Entities;

public class Answer
{
    public AnswerId Id { get; private set; }
    public string Text { get; private set; }
    public bool IsCorrect { get; private set; }
}