using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Auth;

namespace WH.Application.UseCases.Users.Commands.LoginRefreshTokenCommand
{
    public class LoginRefreshTokenCommand : IRequest<BaseResponse<LoginRefreshTokenDto>>
    {
        public string? RefreshToken { get; set; }
    }

}
