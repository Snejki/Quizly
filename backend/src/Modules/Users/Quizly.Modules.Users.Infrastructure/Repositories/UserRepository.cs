using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;

namespace Quizly.Modules.Users.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public Task<User?> GetById(UserId userId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByEmail(Email email, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByLogin(Login login, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task Remove(User remove)
    {
        throw new NotImplementedException();
    }
}