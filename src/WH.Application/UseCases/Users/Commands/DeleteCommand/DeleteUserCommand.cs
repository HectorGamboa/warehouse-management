using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.Users.Commands.DeleteCommand
{
    public class DeleteUserCommand : IRequest<BaseResponse<bool>>
    {
        public int UserId { get; set; }
    }

}
