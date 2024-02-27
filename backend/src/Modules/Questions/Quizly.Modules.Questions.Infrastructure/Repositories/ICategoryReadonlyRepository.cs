using Ardalis.Specification;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.Repositories;

public interface ICategoryReadonlyRepository
{
    Task<List<TResult>> List<TResult>(ISpecification<Category, TResult> specification, CancellationToken ct = default);
}