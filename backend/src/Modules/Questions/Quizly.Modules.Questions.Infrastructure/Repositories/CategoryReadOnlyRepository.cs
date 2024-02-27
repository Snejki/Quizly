using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Questions.Domain.Entities;
using Quizly.Modules.Questions.Infrastructure.DAL;
using Quizly.Shared.Infrastructure.Repositories;

namespace Quizly.Modules.Questions.Infrastructure.Repositories;

public sealed class CategoryReadOnlyRepository : BaseReadOnlyRepository<Category>, ICategoryReadonlyRepository
{
    public CategoryReadOnlyRepository(QuestionsDbContext dbContext)
        : base(dbContext)
    {
    }

    public CategoryReadOnlyRepository(QuestionsDbContext dbContext, ISpecificationEvaluator specificationEvaluator)
        : base(dbContext, specificationEvaluator)
    {
    }

    public async Task<List<TResult>> List<TResult>(ISpecification<Category, TResult> specification, CancellationToken ct = default)
    {
        return await ListAsync(specification, ct);
    }
}