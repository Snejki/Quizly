using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Users.Domain.Entities;

namespace Quizly.Modules.Users.Infrastructure.DAL;

public sealed class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("schUsers");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}