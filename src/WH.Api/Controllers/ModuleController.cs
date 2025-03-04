using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WH.Application.UseCases.Modules.Queries.GetByIdQuery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WH.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly HttpContext _httpContext;

        public ModuleController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _sender = sender;
            _httpContext = httpContextAccessor.HttpContext!;
        }

        [HttpGet("ModuleByUser")]
        public async Task<IActionResult> GetModuleByUserId()
        {
            var userId = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _sender
                .Send(new GetModuleByUserIdQuery() { UserId = int.Parse(userId!) });

            return Ok(response);
        }
    }

}
