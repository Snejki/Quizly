using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.DAL.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();

        builder.Property(x => x.Type).IsRequired();
        builder.HasMany<Answer>().WithOne().HasForeignKey(x => x.Id).IsRequired();
        builder.HasOne<Category>().WithMany().HasForeignKey(x => x.Id).IsRequired();
    }
}