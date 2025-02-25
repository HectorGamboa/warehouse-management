using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Authentication;
using WH.Application.Interfaces.Services;
using BC = BCrypt.Net.BCrypt;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<BaseResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>();

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
                response.Data = _jwtTokenGenerator.GenerateToken(user);
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
