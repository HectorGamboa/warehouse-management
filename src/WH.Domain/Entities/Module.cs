namespace WH.Domain.Entities
{
    public class Module : BaseEntity
    {
        public int Position { get; init; }
        public string Name { get; init; } = null!;
        public string? Icon { get; init; }
        public string? Route { get; init; }
        public int? FatherId { get; init; }
        public int ? Group { get; init; }
    }
}
