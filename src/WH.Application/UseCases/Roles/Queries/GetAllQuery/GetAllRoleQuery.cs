using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Roles;

namespace WH.Application.UseCases.Roles.Queries.GetAllQuery
{
    public class GetAllRoleQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<RoleResponseDto>>> { }
}
