using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;
using WH.Application.Interfaces.Services;
using WH.Application.Shared;

namespace WH.Application.UseCases.Users.Queries.GetUserRolePermissionsQuery
{
    public class GetUserWithRoleAndPermissionsHandler : IRequestHandler<GetUserWithRoleAndPermissionsQuery, BaseResponse<UserWithRoleAndPermissionsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserWithRoleAndPermissionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<UserWithRoleAndPermissionsDto>> Handle(GetUserWithRoleAndPermissionsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UserWithRoleAndPermissionsDto>();

            try
            {
                var user = await _unitOfWork.User.GetUserWithRoleAndPermissionsAsync(request.UserId);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = Constants.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = user;
                response.Message = Constants.MESSAGE_QUERY;
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
