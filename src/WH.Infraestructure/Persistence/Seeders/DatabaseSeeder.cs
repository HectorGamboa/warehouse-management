using WH.Domain.Entities;
using WH.Infrastructure.Persistence.Context;
using BC = BCrypt.Net.BCrypt;

namespace WH.Infrastructure.Persistence.Seeders
{

    public class  DatabaseSeeder
    {
        private readonly ApplicationDbContext _context;

        public DatabaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
           
            if (!_context.Users.Any())  // Verifica si hay registros antes de insertar
            {
                _context.Users.AddRange(new List<User>{
                    new User { FirstName = "Admin",LastName="",State=true, Email = "admin@whmanegement.com",Password =  BC.HashPassword("12345678") },
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Roles.Any())  // Verifica si hay registros antes de insertar
            {
                _context.Roles.AddRange(new List<Role>{
                new Role { Name = "Admin", State =  true, Description = "Main administrator role" },
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.UserRoles.Any())  // Verifica si hay registros antes de insertar
            {
                _context.UserRoles.AddRange(new List<UserRole>{
                    new UserRole { UserId = 1,RoleId=1},
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Modules.Any()) { // Verifica si hay registros antes de insertar
                _context.Modules.AddRange(new List<Module>{
                    new Module { Name = "Dashboard",Position=0,State=true,Url="/dahsboard",Icon= "fas fa-house",FatherId=null},
                    new Module { Name = "Users",Position=1,State=true,Url="/users",Icon="fas fa-users",FatherId=null},
                    new Module { Name = "Roles",Position=2,State=true,Url="/roles",Icon="fas fa-user-tag",FatherId=null},
                    new Module { Name = "Permissions",Position=3,State=true,Url="/permissions",Icon="fas fa-user-lock",FatherId=null},
                    new Module { Name = "Modules",Position=4,State=true,Url="/modules",Icon="fas fa-bars",FatherId=null},
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.ModuleRoles.Any()) {  // Verifica si hay registros antes de insertar
                _context.ModuleRoles.AddRange(
                    new List<ModuleRole>{
                    new ModuleRole { ModuleId = 1,RoleId=1},
                    new ModuleRole { ModuleId = 2,RoleId=1},
                    new ModuleRole { ModuleId = 3,RoleId=1},
                    new ModuleRole { ModuleId = 4,RoleId=1},
                    new ModuleRole { ModuleId = 5,RoleId=1},
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Permissions.Any()) { // Verifica si hay registros antes de insertar
                { // Verifica si hay registros antes de insertar
                    _context.Permissions.AddRange(
                        new List<Permission>{
                        new Permission { Name = "Dashboard_Read", Slug = "1", Description = "Allows reading dashboard", State = true, MenuId = 1 },
                        new Permission { Name = "Users_Read", Slug = "6", Description = "Allows reading users", State = true, MenuId = 2 },
                        new Permission { Name = "Users_Write", Slug = "7", Description = "Allows writing users", State = true, MenuId = 2 },
                        new Permission { Name = "Users_Delete", Slug = "8", Description = "Allows deleting users", State = true, MenuId = 2 },
                        new Permission { Name = "Users_Update", Slug = "9", Description = "Allows updating users", State = true, MenuId = 2 },
                        new Permission { Name = "Users_Create", Slug = "10", Description = "Allows creating users", State = true, MenuId = 2 },
                        new Permission { Name = "Roles_Read", Slug = "11", Description = "Allows reading roles", State = true, MenuId = 3 },
                        new Permission { Name = "Roles_Write", Slug = "12", Description = "Allows writing roles", State = true, MenuId = 3 },
                        new Permission { Name = "Roles_Delete", Slug = "13", Description = "Allows deleting roles", State = true, MenuId = 3 },
                        new Permission { Name = "Roles_Update", Slug = "14", Description = "Allows updating roles", State = true, MenuId = 3 },
                        new Permission { Name = "Roles_Create", Slug = "15", Description = "Allows creating roles", State = true, MenuId = 3 },
                        new Permission { Name = "Permissions_Read", Slug = "16", Description = "Allows reading permissions", State = true, MenuId = 4 },
                        new Permission { Name = "Permissions_Write", Slug = "17", Description = "Allows writing permissions", State = true, MenuId = 4 },
                        new Permission { Name = "Permissions_Delete", Slug = "18", Description = "Allows deleting permissions", State = true, MenuId = 4 },
                        new Permission { Name = "Permissions_Update", Slug = "19", Description = "Allows updating permissions", State = true, MenuId = 4 },
                        new Permission { Name = "Permissions_Create", Slug = "20", Description = "Allows creating permissions", State = true, MenuId = 4 },
                        new Permission { Name = "Menus_Read", Slug = "21", Description = "Allows reading menus", State = true, MenuId = 5 },
                        new Permission { Name = "Menus_Write", Slug = "22", Description = "Allows writing menus", State = true, MenuId = 5 },
                        new Permission { Name = "Menus_Delete", Slug = "23", Description = "Allows deleting menus", State = true, MenuId = 5 },
                        new Permission { Name = "Menus_Update", Slug = "24", Description = "Allows updating menus", State = true, MenuId = 5 },
                        new Permission { Name = "Menus_Create", Slug = "25", Description = "Allows creating menus", State = true, MenuId = 5 },
                    });
                    await _context.SaveChangesAsync();
                }


                if (!_context.RolePermissions.Any())
                { // Verifica si hay registros antes de insertar
                    _context.RolePermissions.AddRange(
                        new List<RolePermission>{
                        new RolePermission { RoleId = 1, PermissionId = 1, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 2, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 3, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 4, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 5, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 6, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 7, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 8, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 9, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 10, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 11, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 12, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 13, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 14, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 15, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 16, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 17, State=true },
                        new RolePermission { RoleId = 1, PermissionId = 18, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 19, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 20, State=true},
                        new RolePermission { RoleId = 1, PermissionId = 21, State=true },
                        });
                    await _context.SaveChangesAsync();
                }

            }
        }
    }
}
