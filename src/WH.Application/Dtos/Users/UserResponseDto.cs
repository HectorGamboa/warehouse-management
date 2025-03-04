namespace WH.Application.Dtos.Users
{
   public class UserResponseDto
    {
        public int UserId { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? Email { get; init; }
        public bool State { get; init; }
        public string? StateDescription { get; init; }
        public DateTime AuditCreateDate { get; init; }
    }
}
