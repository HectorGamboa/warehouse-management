using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Commons;

namespace WH.Application.UseCases.Users.Queries.GetSelectQuery
{
    public class GetUserSelectQuery : IRequest<BaseResponse<IEnumerable<SelectResponseDto>>>
    {
    }
}
