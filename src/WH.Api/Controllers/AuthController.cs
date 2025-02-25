using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery query)
        {
            var response = await _sender.Send(query);
            return Ok(response);
        }
    }

}
