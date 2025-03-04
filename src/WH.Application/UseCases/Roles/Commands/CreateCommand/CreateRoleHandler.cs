using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;

namespace WH.Application.UseCases.Roles.Commands.CreateCommand
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var role = _mapper.Map<Role>(request);
                await _unitOfWork.Role.CreateAsync(role);
                await _unitOfWork.SaveChangesAsync();

                var menus = request.Menus
                        .Select(menu => new ModuleRole
                        {
                            RoleId = role.Id,
                            ModuleId = menu.MenuId
                        }).ToList();

                var permissions = request.Permissions
                        .Select(permission => new RolePermission
                        {
                            RoleId = role.Id,
                            PermissionId = permission.PermissionId
                        }).ToList();

                await _unitOfWork.Permission.RegisterRolePermissions(permissions);
                await _unitOfWork.Menu.RegisterRoleModules(menus);

                transaction.Commit();
                response.IsSuccess = true;
                response.Message = "Registro exitoso";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }

}
