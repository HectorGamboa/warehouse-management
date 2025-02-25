using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Menus;

namespace WH.Application.UseCases.Menus.Queries.GetByIdQuery
{
    public class GetMenuByUserIdQuery : IRequest<BaseResponse<IEnumerable<MenuResponseDto>>>
    {
        public int UserId { get; set; }
    }
}
