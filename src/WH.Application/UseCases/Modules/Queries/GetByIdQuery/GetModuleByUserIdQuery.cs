using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Modules;

namespace WH.Application.UseCases.Modules.Queries.GetByIdQuery
{
    public class GetModuleByUserIdQuery : IRequest<BaseResponse<IEnumerable<ModuleResponseDto>>>
    {
        public int UserId { get; set; }
    }
}
