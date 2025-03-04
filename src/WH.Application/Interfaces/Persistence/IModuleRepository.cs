using WH.Domain.Entities;

namespace WH.Application.Interfaces.Persistence
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetModuleByUserIdAsync(int userId);
        Task<IEnumerable<Module>> GetModulePermissionByRoleIdAsync(int? roleId);
        Task<bool> RegisterRoleModules(IEnumerable<ModuleRole> menuRoles);
        Task<List<ModuleRole>> GetModuleRolesByRoleId(int roleId);
        Task<bool> DeleteModuleRole(List<ModuleRole> menuRoles);
    }
}
