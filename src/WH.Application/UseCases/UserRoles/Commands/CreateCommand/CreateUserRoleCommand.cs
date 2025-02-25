using MediatR;
using WH.Application.Commons.Bases;

namespace WH.Application.UseCases.UserRoles.Commands.CreateCommand
{
    public class CreateUserRoleCommand : IRequest<BaseResponse<bool>>
    {
        public int UserId { get; init; }
        public int RoleId { get; init; }
        public string? State { get; init; }
    }

}
