using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Auth;
using WH.Application.Interfaces.Authentication;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Users.Commands.LoginRefreshTokenCommand
{
    internal sealed class LoginRefreshTokenHandler : IRequestHandler<LoginRefreshTokenCommand, BaseResponse<LoginRefreshTokenDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginRefreshTokenHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<BaseResponse<LoginRefreshTokenDto>> Handle(LoginRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<LoginRefreshTokenDto>();

            var refreshToken = await _unitOfWork.RefreshToken.GetRefreshTokenAsync(request.RefreshToken!);
            if(refreshToken == null){
               throw new UnauthorizedAccessException("Invalid refresh token");
            }
            if (refreshToken.ExpiresOnUtc < DateTime.UtcNow)
            {
               throw new UnauthorizedAccessException("The refresh token has expired.");
            }

            string accessToken = _jwtTokenGenerator.GenerateToken(refreshToken.User);
            refreshToken.Token = _jwtTokenGenerator.GenerateRefreshToken();
            refreshToken.ExpiresOnUtc = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;

            var data = new LoginRefreshTokenDto { AccessToken = accessToken, RefreshToken = refreshToken.Token };

            response.Data = data;
            response.Message = "Refresh token created successfully.";
            return response;
        }
    }

}
