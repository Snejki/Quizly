using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Domain.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Category?> GetById(CategoryId id, CancellationToken ct);
        public Task<Category?> GetByName(string name, CancellationToken ct);
        public Task Add(Category category, CancellationToken ct);
    }
}
