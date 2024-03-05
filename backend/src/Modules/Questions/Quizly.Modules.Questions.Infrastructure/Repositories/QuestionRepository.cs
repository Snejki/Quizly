using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Domain.Repositories;
using Quizly.Modules.Questions.Infrastructure.DAL;

namespace Quizly.Modules.Questions.Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly QuestionsDbContext _dbContext;

    public QuestionRepository(QuestionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Question?> GetById(QuestionId id, CancellationToken ct = default) =>
        await _dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task Add(Question question, CancellationToken ct = default)
    {
        await _dbContext.AddAsync(question, ct);
        await _dbContext.SaveChangesAsync(ct);
    }
}