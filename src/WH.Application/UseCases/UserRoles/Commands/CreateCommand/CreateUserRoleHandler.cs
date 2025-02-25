using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;

namespace WH.Application.UseCases.UserRoles.Commands.CreateCommand
{
    public class CreateUserRoleHandler : IRequestHandler<CreateUserRoleCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserRoleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var userRole = _mapper.Map<UserRole>(request);
                await _unitOfWork.UserRole.CreateAsync(userRole);
                await _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Registro exitoso";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
