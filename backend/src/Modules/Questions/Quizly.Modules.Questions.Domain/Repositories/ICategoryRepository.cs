using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetList(CancellationToken ct = default);
        public Task<Category?> GetById(CategoryId id, CancellationToken ct = default);
        public Task<Category?> GetByName(string name, CancellationToken ct = default);
        public Task Add(Category category, CancellationToken ct = default);
    }
}
