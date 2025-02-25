using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.UserRoles.Commands.DeleteCommand
{
    public class DeleteUserRoleCommand : IRequest<BaseResponse<bool>>
    {
        public int UserRoleId { get; init; }
    }
}
