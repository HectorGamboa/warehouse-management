namespace WH.Application.Dtos.Modules
{
    public record ModuleResponseDto
    {
        public int MenuId { get; init; }
        public string? Item { get; init; }
        public string? Icon { get; init; }
        public string? Route { get; init; }
       
        public int FatherId { get; init; }
    }
}
