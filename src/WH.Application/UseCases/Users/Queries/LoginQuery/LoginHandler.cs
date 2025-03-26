using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Auth;
using WH.Application.Interfaces.Authentication;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;
using BC = BCrypt.Net.BCrypt;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<LoginUserResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<LoginUserResponseDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<LoginUserResponseDto>();

            try
            {
                var user = await _unitOfWork.User.UserByEmailAsync(request.Email);
               
                if (user is null)
                {
                    throw new UnauthorizedAccessException("Invalid credentials.");
                }

                if (user.IsDelete || user.State == false)
                {
                    throw new UnauthorizedAccessException("The user is inactive, contact support.");
                }

                if (!BC.Verify(request.Password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid credentials.");                    
                }
                response.IsSuccess = true;
                var accessToken = _jwtTokenGenerator.GenerateToken(user);

                var refreshToken = new RefreshToken
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Token = _jwtTokenGenerator.GenerateRefreshToken(),
                    ExpiresOnUtc = DateTime.UtcNow.AddDays(7)
                };

                _unitOfWork.RefreshToken.CreateToken(refreshToken);
                await _unitOfWork.SaveChangesAsync();
                response.Data = new LoginUserResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken.Token
                };
                    response.Message = "Token generated successfully";
            }
            catch (Exception)
            {
                throw ; 
            }

            return response;
        }
    }

}
