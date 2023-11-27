using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizly.Modules.Users.Domain.Entities;

namespace Quizly.Modules.Users.Infrastructure.DAL.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Token).IsRequired();

        builder.Property(x => x.ValidTill).IsRequired();

        builder.Property(x => x.Userid).IsRequired();
    }
}