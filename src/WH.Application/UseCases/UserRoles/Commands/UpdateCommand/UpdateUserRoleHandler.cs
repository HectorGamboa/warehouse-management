using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;

namespace WH.Application.UseCases.UserRoles.Commands.UpdateCommand
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserRoleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var userRole = _mapper.Map<UserRole>(request);
                userRole.Id = request.UserRoleId;
                _unitOfWork.UserRole.UpdateAsync(userRole);
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
