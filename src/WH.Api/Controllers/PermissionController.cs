﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WH.Application.UseCases.Permissions.Queries.GetByIdQuery;

namespace WH.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly ISender _sender;

        public PermissionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("PermissionByRoleId/{roleId:int}")]
        public async Task<IActionResult> GetPermissionsByRoleId(int roleId)
        {
            var response = await _sender.Send(new GetPermissionsByRoleIdQuery { RoleId = roleId });
            return Ok(response);
        }
    }

}
