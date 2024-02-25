using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quizly.Modules.Questions.Domain;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.Repositories
{
    public interface ICategoryRepository
    {
        public Task<Category?> GetById(CategoryId id);
        public Task<Category?> GetByName(string name);
        public Task Add(Category category);
    }
}
