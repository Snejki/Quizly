using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Domain.Repositories;

public interface IQuestionRepository
{
    public Task<Question?> GetById(QuestionId id, CancellationToken ct = default);
    public Task Add(Question question, CancellationToken ct = default);
}