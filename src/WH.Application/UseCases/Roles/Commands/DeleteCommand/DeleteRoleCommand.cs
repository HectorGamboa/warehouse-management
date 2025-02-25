using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.Roles.Commands.DeleteCommand
{
    public class DeleteRoleCommand : IRequest<BaseResponse<bool>>
    {
        public int RoleId { get; set; }
    }

}
