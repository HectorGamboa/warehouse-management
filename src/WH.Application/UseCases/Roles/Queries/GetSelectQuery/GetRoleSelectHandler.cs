using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Constants;
using WH.Application.Dtos.Commons;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Roles.Queries.GetSelectQuery
{
    public class GetRoleSelectHandler : IRequestHandler<GetRoleSelectQuery, BaseResponse<IEnumerable<SelectResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoleSelectHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SelectResponseDto>>> Handle(GetRoleSelectQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<SelectResponseDto>>();

            try
            {
                var roles = await _unitOfWork.Role.GetAllAsync();

                if (roles is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<SelectResponseDto>>(roles);
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
