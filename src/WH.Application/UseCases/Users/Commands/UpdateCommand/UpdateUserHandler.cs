using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;
using BC = BCrypt.Net.BCrypt;

namespace WH.Application.UseCases.Users.Commands.UpdateCommand
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var user = _mapper.Map<User>(request);
                user.Id = request.UserId;
                user.Password = BC.HashPassword(user.Password);
                _unitOfWork.User.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Actualización exitosa";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
