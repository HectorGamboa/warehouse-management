using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Dtos.Users;
using WH.Application.Interfaces.Authentication;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;
using BC = BCrypt.Net.BCrypt;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<UserByIdResponseDto>>
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

        public async Task<BaseResponse<UserByIdResponseDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<UserByIdResponseDto>();

            try
            {
                var user = await _unitOfWork.User.UserByEmailAsync(request.Email);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = "El usuario no existe en la base de datos.";
                    return response;
                }

                if (!BC.Verify(request.Password, user.Password))
                {
                    response.IsSuccess = false;
                    response.Message = "La contraseña es incorrecta.";
                    return response;
                }

                response.IsSuccess = true;
                response.AccessToken = _jwtTokenGenerator.GenerateToken(user);

                var refreshToken = new RefreshToken
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    Token = _jwtTokenGenerator.GenerateRefreshToken(),
                    ExpiresOnUtc = DateTime.UtcNow.AddDays(7)
                };

                _unitOfWork.RefreshToken.CreateToken(refreshToken);
                await _unitOfWork.SaveChangesAsync();
                response.Data = _mapper.Map<UserByIdResponseDto>(user);
                response.RefreshToken = refreshToken.Token;
                response.Message = "Token generado correctamente";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
