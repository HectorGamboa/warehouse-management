using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginQuery : IRequest<BaseResponse<UserByIdResponseDto>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}
