namespace Quizly.Modules.Questions.Domain.Entities;

public record Answer
{
    // todo: to value object
    public string Text { get; private set; }
    public bool IsCorrect { get; private set; }

    public Answer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }
}