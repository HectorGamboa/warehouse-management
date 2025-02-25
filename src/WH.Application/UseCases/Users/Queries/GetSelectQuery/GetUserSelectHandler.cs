using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Constants;
using WH.Application.Dtos.Commons;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Users.Queries.GetSelectQuery
{
    public class GetUserSelectHandler : IRequestHandler<GetUserSelectQuery, BaseResponse<IEnumerable<SelectResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserSelectHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<SelectResponseDto>>> Handle(GetUserSelectQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<SelectResponseDto>>();

            try
            {
                var users = await _unitOfWork.User.GetAllAsync();

                if (users is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<SelectResponseDto>>(users);
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
