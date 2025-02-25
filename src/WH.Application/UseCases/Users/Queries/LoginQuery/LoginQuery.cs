using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginQuery : IRequest<BaseResponse<string>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
