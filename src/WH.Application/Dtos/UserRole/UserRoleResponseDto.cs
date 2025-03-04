namespace WH.Application.Dtos.UserRole
{
    public record UserRoleResponseDto
    {
        public int UserRoleId { get; init; }
        public string User { get; init; } = null!;
        public string Role { get; init; } = null!;
        public bool? State { get; init; }
        public string? StateDescription { get; init; }
        public DateTime AuditCreateDate { get; init; }
    }
}
