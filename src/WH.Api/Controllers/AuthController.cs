using MediatR;
using Microsoft.AspNetCore.Mvc;
using WH.Application.UseCases.Users.Commands.LoginRefreshTokenCommand;
using WH.Application.UseCases.Users.Commands.RevokeRefreshTokenCommand;
using WH.Application.UseCases.Users.Queries.LoginQuery;

namespace WH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery request)
        {
            var response = await _sender.Send(request);
            return Ok(response);
        }

        [HttpPost("login-refreshtoken")]
        public async Task<IActionResult> LoginRefreshToken([FromBody] LoginRefreshTokenCommand request)
        {
            var response = await _sender.Send(request);
            return Ok(response);
        }

        [HttpPost("revoke-refreshtoken")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] RevokeRefreshTokenCommand request)
        {
            var response = await _sender.Send(request);
            return Ok(response);
        }
    }

}
