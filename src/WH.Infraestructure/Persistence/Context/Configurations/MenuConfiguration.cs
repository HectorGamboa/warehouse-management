using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("MenuId");

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Icon)
                    .HasMaxLength(50);

            builder.Property(e => e.Url)
                .HasMaxLength(150);
        }
    }
}