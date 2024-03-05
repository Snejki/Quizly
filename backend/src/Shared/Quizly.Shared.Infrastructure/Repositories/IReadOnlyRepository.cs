using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Quizly.Shared.Infrastructure.Repositories;

#pragma warning disable S2326
public interface IReadOnlyRepository<TContext, TEntity>
#pragma warning restore S2326
    where TContext : DbContext
{
    Task<List<TResult>> List<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken ct = default);
}