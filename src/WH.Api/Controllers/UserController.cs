using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using WH.Application.UseCases.Users.Commands.CreateCommand;
using WH.Application.UseCases.Users.Commands.DeleteCommand;
using WH.Application.UseCases.Users.Commands.UpdateCommand;
using WH.Application.UseCases.Users.Queries.GetAllQuery;
using WH.Application.UseCases.Users.Queries.GetByIdQuery;
using WH.Application.UseCases.Users.Queries.GetSelectQuery;
using WH.Application.UseCases.Users.Queries.GetUserRolePermissionsQuery;
using WH.Domain.Entities;
using WH.Infrastructure.Authentication;
using Permission = WH.Infrastructure.Authentication.Permission;

namespace WH.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly HttpContext _httpContext;
        public UserController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _sender = sender;
            _httpContext = httpContextAccessor.HttpContext!;
        }
        [HasPermission(Permission.Users_Read)]
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

        [AllowAnonymous]
        [HttpGet("UserWithRoleAndPermissions/{userId:int}")]
        public async Task<IActionResult> UserWithRoleAndPermissions(int userId)
        {
            var response = await _sender.Send(new GetUserWithRoleAndPermissionsQuery { UserId = userId });
            return Ok(response);
        }
        [HasPermission(Permission.Users_Create)]
        [HttpPost("Create")]
        public async Task<IActionResult> UserCreate([FromBody] CreateUserCommand command)
        {
            var  _userId = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var firstName = _httpContext.User.FindFirst(ClaimTypes.GivenName)?.Value;
            var lastName = _httpContext.User.FindFirst(ClaimTypes.Surname)?.Value;
            command.UserAction = firstName +" "+ lastName;
            command.IdUserAction = int.Parse(_userId!);
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
