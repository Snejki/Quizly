using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Quizly.Shared.Infrastructure.Repositories;

public sealed class ReadOnlyRepository<TContext, TEntity> : RepositoryBase<TEntity>, IReadOnlyRepository<TContext, TEntity>
    where TContext : DbContext
    where TEntity : class
{
    public ReadOnlyRepository(TContext dbContext)
        : base(dbContext)
    {
    }

    public ReadOnlyRepository(DbContext dbContext, ISpecificationEvaluator specificationEvaluator)
        : base(dbContext, specificationEvaluator)
    {
    }

    public async Task<List<TResult>> List<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken ct = default)
    {
        return await ListAsync(specification, ct);
    }
}