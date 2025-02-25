﻿namespace WH.Application.Dtos.Permissions
{
    public class PermissionsByRoleResponseDto
    {
        public int MenuId { get; set; }
        public string Menu { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public IEnumerable<PermissionsResponseDto> Permissions { get; set; } = null!;
    }
}
