using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WH.Application.UseCases.Users.Commands.CreateCommand;
using WH.Application.UseCases.Users.Commands.DeleteCommand;
using WH.Application.UseCases.Users.Commands.UpdateCommand;
using WH.Application.UseCases.Users.Queries.GetAllQuery;
using WH.Application.UseCases.Users.Queries.GetByIdQuery;
using WH.Application.UseCases.Users.Queries.GetSelectQuery;

namespace WH.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> UserList([FromQuery] GetAllUserQuery query)
        {
            var response = await _sender.Send(query);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> UserSelect()
        {
            var response = await _sender.Send(new GetUserSelectQuery());
            return Ok(response);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> UserById(int userId)
        {
            var response = await _sender.Send(new GetUserByIdQuery { UserId = userId });
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> UserCreate([FromBody] CreateUserCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UserUpdate([FromBody] UpdateUserCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }

        [HttpPut("Delete/{userId:int}")]
        public async Task<IActionResult> UserDelete(int userId)
        {
            var response = await _sender.Send(new DeleteUserCommand() { UserId = userId });
            return Ok(response);
        }
    }

}
