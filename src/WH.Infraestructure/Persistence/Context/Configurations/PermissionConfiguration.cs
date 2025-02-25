using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("PermissionId");

            builder.Property(e => e.Name)
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                    .HasMaxLength(255);
        }
    }
}
