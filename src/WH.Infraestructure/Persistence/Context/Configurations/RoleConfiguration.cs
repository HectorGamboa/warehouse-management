using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("RoleId");

            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                    .HasMaxLength(255);
        }
    }
}

