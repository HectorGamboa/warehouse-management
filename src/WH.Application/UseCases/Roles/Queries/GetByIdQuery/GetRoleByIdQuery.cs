using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Roles;

namespace WH.Application.UseCases.Roles.Queries.GetByIdQuery
{
    public class GetRoleByIdQuery : IRequest<BaseResponse<RoleByIdResponseDto>>
    {
        public int RoleId { get; set; }
    }
}
