using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.UserRole;

namespace WH.Application.UseCases.UserRoles.Queries.GetByIdQuery
{
    public class GetUserRoleByIdQuery : IRequest<BaseResponse<UserRoleByIdResponseDto>>
    {
        public int UserRoleId { get; init; }
    }
}
