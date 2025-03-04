using Microsoft.EntityFrameworkCore;
using WH.Application.Interfaces.Persistence;
using WH.Domain.Entities;
using WH.Infrastructure.Persistence.Context;

namespace WH.Infrastructure.Persistence.Repositories
{
    public class ModuleRepository(ApplicationDbContext context) : IModuleRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> DeleteModuleRole(List<ModuleRole> moduleRoles)
        {
            _context.ModuleRoles.RemoveRange(moduleRoles);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<IEnumerable<Module>> GetModuleByUserIdAsync(int userId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);

            var modules = await _context.Modules
                .AsNoTracking()
                .AsSplitQuery()
                .Join(_context.ModuleRoles, m => m.Id, mr => mr.ModuleId, (m, mr) => new { Module = m, ModuleRole = mr })
                .Where(x => x.ModuleRole.RoleId == userRole!.RoleId && x.Module.State == true)
                .Select(x => x.Module)
                .ToListAsync();

            return modules;
        }

        public async Task<IEnumerable<Module>> GetModulePermissionByRoleIdAsync(int? roleId)
        {
            var query = _context.Modules
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Where(m => m.Url != null && m.State == true);

            //if (roleId != 0)
            //{
            //    var menus = await query
            //        .Join(_context.MenuRoles, m => m.Id, mr => mr.MenuId, (m, mr) => new { Menu = m, MenuRole = mr })
            //        .Where(x => x.MenuRole.RoleId == roleId)
            //        .Select(x => x.Menu)
            //        .ToListAsync();

            //    return menus;
            //}
            //else
            //{
            var modules = await query.ToListAsync();
            return modules;
            //}
        }

        public async Task<List<ModuleRole>> GetModuleRolesByRoleId(int roleId)
        {
            return await _context.ModuleRoles
                    .AsNoTracking()
                    .Where(pr => pr.RoleId == roleId)
                    .ToListAsync();
        }

        public async Task<bool> RegisterRoleModules(IEnumerable<ModuleRole> moduleRoles)
        {
            foreach (var moduleRole in moduleRoles)
            {
                moduleRole.AuditCreateDate = DateTime.Now;
                moduleRole.State = true;

                _context.ModuleRoles.Add(moduleRole);
            }

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}