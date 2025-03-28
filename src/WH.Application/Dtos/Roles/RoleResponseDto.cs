﻿namespace WH.Application.Dtos.Roles
{
    public record RoleResponseDto
    {
        public int RoleId { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
        public bool State { get; init; }
        public string? StateDescription { get; init; }
        public DateTime AuditCreateDate { get; init; }
    }
}
