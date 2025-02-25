using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.UserRoles.Commands.UpdateCommand
{
    public class UpdateUserRoleCommand : IRequest<BaseResponse<bool>>
    {
        public int UserRoleId { get; init; }
        public int UserId { get; init; }
        public int RoleId { get; init; }
        public string? State { get; init; }
    }

}
