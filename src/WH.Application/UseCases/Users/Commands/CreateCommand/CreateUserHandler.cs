using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;
using BC = BCrypt.Net.BCrypt;
using WH.Application.Shared;

namespace WH.Application.UseCases.Users.Commands.CreateCommand
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                // obtenemos el  token del usuario
               
                var user = _mapper.Map<User>(request);
                user.Password = BC.HashPassword(user.Password);
                await _unitOfWork.User.CreateAsync(user);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.Bitacora.CreateAsync(
                    new Bitacora
                    {
                        ModuleId = Constants.Module_Users,
                        Module = "Users",
                        UserId = request.IdUserAction,
                        Message = "El  usuario con ID:" + request.IdUserAction + " " + request.UserAction + " creo  al usuario #" + user.Id,
                        Action = "Crear",
                        Date = DateTime.Now,
                        ActionResult = true,
                        State = true
                    });
                await _unitOfWork.SaveChangesAsync();
                response.IsSuccess = true;
                response.Message = "Registro exitoso";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
               await _unitOfWork.Bitacora.CreateAsync(
               new Bitacora
                {
                    ModuleId = Constants.Module_Users,
                    Module = "Users",
                    UserId = request.IdUserAction,
                    Message = "El  usuario con ID:" + request.IdUserAction + " " + request.UserAction + " Intento crear un usuario Error :"
                    + ex.Message,
                    Action = "Crear",
                    Date = DateTime.Now,
                    ActionResult = false
                });
            }

            return response;
        }
    }

}
