using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.Users.Commands.RevokeRefreshTokenCommand
{
    public class RevokeRefreshTokenCommand : IRequest<BaseResponse<bool>>
    {
        public int UserId { get; set; }
    }

}
