using Quizly.Modules.Users.Domain.Entities;

namespace Quizly.Modules.Users.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(UserId userId, CancellationToken ct = default);
    Task<User?> GetByEmail(Email email, CancellationToken ct = default);
    Task<User?> GetByLogin(Login login, CancellationToken ct = default);

    Task Add(User user, CancellationToken ct = default);
    Task Update(User user, CancellationToken ct = default);
    Task Remove(User user, CancellationToken ct = default);
}