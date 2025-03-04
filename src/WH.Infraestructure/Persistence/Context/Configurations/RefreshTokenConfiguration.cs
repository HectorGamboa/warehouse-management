using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Token).HasMaxLength(200);

            builder.HasIndex(e => e.Token).IsUnique();

            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}
