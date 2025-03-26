using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Users.Commands.RevokeRefreshTokenCommand
{
    internal sealed class RevokeRefreshTokenHandler(IUnitOfWork unitOfWork) : IRequestHandler<RevokeRefreshTokenCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResponse<bool>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                await _unitOfWork.RefreshToken.RevokeRefreshTokenAsync(request.RefreshToken!);
                response.IsSuccess = true;
                response.Message = "Successfully revoked the refresh token.";
            }
            catch (Exception )
            {
                throw;
            }

            return response;
        }
    }
}
