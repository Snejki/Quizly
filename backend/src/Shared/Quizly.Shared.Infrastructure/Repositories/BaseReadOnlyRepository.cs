using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Quizly.Shared.Infrastructure.Repositories;

public class BaseReadOnlyRepository<T> : RepositoryBase<T>
    where T : class
{
    public BaseReadOnlyRepository(DbContext dbContext)
        : base(dbContext)
    {
    }

    public BaseReadOnlyRepository(DbContext dbContext, ISpecificationEvaluator specificationEvaluator)
        : base(dbContext, specificationEvaluator)
    {
    }
}