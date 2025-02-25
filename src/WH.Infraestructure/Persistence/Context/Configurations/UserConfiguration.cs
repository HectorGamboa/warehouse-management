using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("UserId");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasMaxLength(100);

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}