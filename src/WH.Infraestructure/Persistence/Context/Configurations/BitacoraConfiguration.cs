using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    public class BitacoraConfiguration : IEntityTypeConfiguration<Bitacora>
    {
        public void Configure(EntityTypeBuilder<Bitacora> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("LogId");
            builder.Property(e => e.Message)
                .HasMaxLength(500);
            builder.Property(e => e.Module)
                .HasMaxLength(150)
                .IsUnicode(false);
            builder.Property(e => e.Action)
                .HasMaxLength(150)
                .IsUnicode(false);
            builder.Property(e => e.UserId)
                .HasColumnName("UserId");
            builder.Property(e => e.Date)
                .HasColumnName("Date");
        }
    }
}
