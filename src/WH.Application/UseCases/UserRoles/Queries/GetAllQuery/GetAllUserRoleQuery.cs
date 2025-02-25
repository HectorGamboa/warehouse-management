using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.UserRole;

namespace WH.Application.UseCases.UserRoles.Queries.GetAllQuery
{
    public class GetAllUserRoleQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<UserRoleResponseDto>>> { }

}
