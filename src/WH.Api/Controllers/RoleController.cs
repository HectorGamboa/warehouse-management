using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WH.Application.UseCases.Roles.Commands.CreateCommand;
using WH.Application.UseCases.Roles.Commands.DeleteCommand;
using WH.Application.UseCases.Roles.Commands.UpdateCommand;
using WH.Application.UseCases.Roles.Queries.GetAllQuery;
using WH.Application.UseCases.Roles.Queries.GetByIdQuery;
using WH.Application.UseCases.Roles.Queries.GetSelectQuery;

namespace WH.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ISender _sender;

        public RoleController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> RoleList([FromQuery] GetAllRoleQuery query)
        {
            var response = await _sender.Send(query);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> RoleSelect()
        {
            var response = await _sender.Send(new GetRoleSelectQuery());
            return Ok(response);
        }

        [HttpGet("{roleId:int}")]
        public async Task<IActionResult> RoleById(int roleId)
        {
            var response = await _sender.Send(new GetRoleByIdQuery { RoleId = roleId });
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> RoleCreate([FromBody] CreateRoleCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> RoleUpdate([FromBody] UpdateRoleCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }

        [HttpPut("Delete/{roleId:int}")]
        public async Task<IActionResult> RoleDelete(int roleId)
        {
            var response = await _sender.Send(new DeleteRoleCommand() { RoleId = roleId });
            return Ok(response);
        }
    }

}
