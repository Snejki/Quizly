using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Domain.Repositories;
using Quizly.Modules.Questions.Infrastructure.DAL;

namespace Quizly.Modules.Questions.Infrastructure.Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly QuestionsDbContext _questionsDbContext;

    public CategoryRepository(QuestionsDbContext questionsDbContext)
    {
        _questionsDbContext = questionsDbContext;
    }

    public async Task<Category?> GetById(CategoryId id, CancellationToken ct)
    {
        return await _questionsDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<Category?> GetByName(string name, CancellationToken ct)
    {
        return await _questionsDbContext.Categories.FirstOrDefaultAsync(x => x.Name.Trim() == name.Trim(), ct);
    }

    public async Task Add(Category category, CancellationToken ct)
    {
        await _questionsDbContext.Categories.AddAsync(category, ct);
        await _questionsDbContext.SaveChangesAsync(ct);
    }
}