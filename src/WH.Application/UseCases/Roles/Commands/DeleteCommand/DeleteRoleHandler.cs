using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;

namespace WH.Application.UseCases.Roles.Commands.DeleteCommand
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var existsRole = await _unitOfWork.Role.GetByIdAsync(request.RoleId);

                if (existsRole is null)
                {
                    response.IsSuccess = false;
                    response.Message = "El rol no existe en la base de datos.";
                    return response;
                }

                await _unitOfWork.Role.DeleteAsync(request.RoleId);
                await _unitOfWork.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Eliminación exitosa.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
