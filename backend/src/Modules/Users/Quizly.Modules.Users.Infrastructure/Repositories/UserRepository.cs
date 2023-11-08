using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;
using Quizly.Modules.Users.Domain.Repositories;
using Quizly.Modules.Users.Infrastructure.DAL;

namespace Quizly.Modules.Users.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly UsersDbContext _usersDbContext;

    public UserRepository(UsersDbContext usersDbContext)
    {
        _usersDbContext = usersDbContext;
    }

    public async Task<User?> GetById(UserId userId, CancellationToken ct = default) =>
        await _usersDbContext.Users.SingleOrDefaultAsync(x => x.Id == userId, ct);

    public async Task<User?> GetByEmail(Email email, CancellationToken ct = default) =>
        await _usersDbContext.Users.SingleOrDefaultAsync(x => x.Email == email, ct);

    public async Task<User?> GetByLogin(Login login, CancellationToken ct = default) =>
        await _usersDbContext.Users.SingleOrDefaultAsync(x => x.Login == login, ct);

    public async Task Add(User user, CancellationToken ct = default)
    {
        _usersDbContext.Users.Add(user);
        await _usersDbContext.SaveChangesAsync(ct);
    }

    public async Task Update(User user, CancellationToken ct = default)
    {
        _usersDbContext.Users.Update(user);
        await _usersDbContext.SaveChangesAsync(ct);
    }

    public async Task Remove(User user, CancellationToken ct = default)
    {
        _usersDbContext.Remove(user);
        await _usersDbContext.SaveChangesAsync(ct);
    }
}