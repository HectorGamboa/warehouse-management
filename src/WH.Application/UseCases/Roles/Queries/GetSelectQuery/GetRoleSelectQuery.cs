using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Commons;

namespace WH.Application.UseCases.Roles.Queries.GetSelectQuery
{
    public class GetRoleSelectQuery : IRequest<BaseResponse<IEnumerable<SelectResponseDto>>>
    {
    }
}
