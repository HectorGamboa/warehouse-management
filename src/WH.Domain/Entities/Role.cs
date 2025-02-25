namespace WH.Domain.Entities
{
    public class Role: BaseEntity
    {
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
    }
}
