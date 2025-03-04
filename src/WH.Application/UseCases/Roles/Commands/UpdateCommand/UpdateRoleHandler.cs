using AutoMapper;
using MediatR;
using WH.Application.Commons.Bases;
using WH.Application.Interfaces.Services;
using WH.Domain.Entities;

namespace WH.Application.UseCases.Roles.Commands.UpdateCommand
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoleHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var role = _mapper.Map<Role>(request);
                role.Id = request.RoleId;
                _unitOfWork.Role.UpdateAsync(role);
                await _unitOfWork.SaveChangesAsync();

                var existingPermissions = await _unitOfWork.Permission
                        .GetPermissionRolesByRoleId(request.RoleId);

                var existingMenus = await _unitOfWork.Menu
                        .GetModuleRolesByRoleId(request.RoleId);

                var newPermissions = request.Permissions
                        .Where(p => p.Selected && !existingPermissions.Any(ep => ep.PermissionId == p.PermissionId))
                        .Select(p => new RolePermission
                        {
                            RoleId = role.Id,
                            PermissionId = p.PermissionId
                        });

                await _unitOfWork.Permission.RegisterRolePermissions(newPermissions);

                var newMenus = request.Menus
                        .Where(p => !existingMenus.Any(ep => ep.ModuleId == p.MenuId))
                        .Select(p => new ModuleRole
                        {
                            RoleId = role.Id,
                            ModuleId = p.MenuId
                        });

                await _unitOfWork.Menu.RegisterRoleModules(newMenus);

                var permissionsToDelete = existingPermissions
                        .Where(ep => !request.Permissions.Any(p => p.PermissionId == ep.PermissionId && p.Selected))
                        .ToList();

                await _unitOfWork.Permission.DeleteRolePermission(permissionsToDelete);

                var menusToDelete = existingMenus
                        .Where(ep => !request.Menus.Any(p => p.MenuId == ep.ModuleId))
                        .ToList();

                await _unitOfWork.Menu.DeleteModuleRole(menusToDelete);

                transaction.Commit();
                response.IsSuccess = true;
                response.Message = "Actualización exitosa";
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
