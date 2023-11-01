using Quizly.Modules.Users.Domain.Entities;

namespace Quizly.Modules.Users.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetById(UserId userId, CancellationToken ct = default);
    Task<User> GetByEmail(Email email, CancellationToken ct = default);

    Task Add(User user);
    Task Update(User user);
    Task Remove(User remove);
}