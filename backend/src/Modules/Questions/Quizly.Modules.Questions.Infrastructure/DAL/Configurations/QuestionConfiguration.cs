using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Quizly.Modules.Questions.Domain.Entities;

namespace Quizly.Modules.Questions.Infrastructure.DAL.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Id, x => new (x)).IsRequired();

        builder.Property(x => x.Type).IsRequired();
        builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId).IsRequired();

        // todo: find better solution
        builder.Property(x => x.Answers).HasConversion(
            x => JsonConvert.SerializeObject(x),
            x => JsonConvert.DeserializeObject<List<Answer>>(x))
            .IsRequired();
    }
}