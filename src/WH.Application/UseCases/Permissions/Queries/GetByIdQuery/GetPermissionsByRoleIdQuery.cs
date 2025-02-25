using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Permissions;

namespace WH.Application.UseCases.Permissions.Queries.GetByIdQuery
{
    public class GetPermissionsByRoleIdQuery : IRequest<BaseResponse<IEnumerable<PermissionsByRoleResponseDto>>>
    {
        public int? RoleId { get; set; }
    }
}
