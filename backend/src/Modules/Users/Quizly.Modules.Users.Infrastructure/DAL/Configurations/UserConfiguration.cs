using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizly.Modules.Users.Domain;
using Quizly.Modules.Users.Domain.Entities;

namespace Quizly.Modules.Users.Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, x => new UserId(x)).IsRequired();

        builder
            .HasIndex(x => x.Login).IsUnique();
        builder.Property(x => x.Login).HasConversion(x => x.Value, x => new Login(x)).IsRequired();

        builder
            .HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email).HasConversion(x => x.Value, x => new Email(x)).IsRequired();

        builder.OwnsOne(x => x.Password);

        builder.OwnsOne(x => x.Avatar);
        builder.Property(x => x.CreatedAt).IsRequired();

        builder.HasMany<RefreshToken>().WithOne().HasForeignKey(x => x.Userid);
    }
}