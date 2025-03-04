namespace WH.Domain.Entities
{
    public class ModuleRole:BaseEntity
    {
        public int ModuleId { get; init; }
        public int RoleId { get; init; }
        public Module Menu { get; init; } = null!;
        public Role Role { get; init; } = null!;
    }
}
