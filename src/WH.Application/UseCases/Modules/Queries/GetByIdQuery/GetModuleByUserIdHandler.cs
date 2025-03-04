using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Modules;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Modules.Queries.GetByIdQuery
{
    public class GetModuleByUserIdHandler : IRequestHandler<GetModuleByUserIdQuery, BaseResponse<IEnumerable<ModuleResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetModuleByUserIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ModuleResponseDto>>> Handle(GetModuleByUserIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<ModuleResponseDto>>();

            try
            {
                var menus = await _unitOfWork.Menu.GetModuleByUserIdAsync(request.UserId);

                if (menus is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron registros.";
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<ModuleResponseDto>>(menus);
                response.Message = "Consulta exitosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
