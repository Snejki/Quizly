using Microsoft.EntityFrameworkCore;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.DAL;

public class QuestionsDbContext : DbContext
{
    public QuestionsDbContext(DbContextOptions<QuestionsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionsDbContext).Assembly);
    }
}