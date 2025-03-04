using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.Users.Commands.LoginRefreshTokenCommand
{
    public class LoginRefreshTokenCommand : IRequest<BaseResponse<string>>
    {
        public string? RefreshToken { get; set; }
    }

}
