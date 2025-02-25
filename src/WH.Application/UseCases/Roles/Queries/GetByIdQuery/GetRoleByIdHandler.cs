using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Roles;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Roles.Queries.GetByIdQuery
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, BaseResponse<RoleByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<RoleByIdResponseDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<RoleByIdResponseDto>();

            try
            {
                var role = await _unitOfWork.Role.GetByIdAsync(request.RoleId);

                if (role is null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se encontraron registros.";
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<RoleByIdResponseDto>(role);
                response.Message = "Consulta exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
