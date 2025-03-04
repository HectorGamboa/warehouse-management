using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WH.Domain.Entities;

namespace WH.Infrastructure.Persistence.Context.Configurations
{
    public class ModuleRoleConfiguration : IEntityTypeConfiguration<ModuleRole>
    {
        public void Configure(EntityTypeBuilder<ModuleRole> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey(e => new { e.ModuleId, e.RoleId });
        }
    }
}
