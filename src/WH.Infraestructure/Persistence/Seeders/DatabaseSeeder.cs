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
                    new User { FirstName = "Admin",LastName="",State="1", Email = "admin@whmanegement.com",Password =  BC.HashPassword("12345678") },
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Roles.Any())  // Verifica si hay registros antes de insertar
            {
                _context.Roles.AddRange(new List<Role>{
                new Role { Name = "Admin", State = "1", Description = "Main administrator role" },
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
            if (!_context.Menus.Any()) { // Verifica si hay registros antes de insertar
                _context.Menus.AddRange(new List<Menu>{
                    new Menu { Name = "Dashboard",Position=0,State="1",Url="/dahsboard",Icon= "fas fa-house",FatherId=null},
                    new Menu { Name = "Usuarios",Position=1,State="1",Url="/users",Icon="fas fa-users",FatherId=null},
                    new Menu { Name = "Roles",Position=2,State="1",Url="/roles",Icon="fas fa-user-tag",FatherId=null},
                    new Menu { Name = "Permisos",Position=3,State="1",Url="/permissions",Icon="fas fa-user-lock",FatherId=null},
                    new Menu { Name = "Menus",Position=4,State="1",Url="/menus",Icon="fas fa-bars",FatherId=null},
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.MenuRoles.Any()) {  // Verifica si hay registros antes de insertar
                _context.MenuRoles.AddRange(
                    new List<MenuRole>{
                    new MenuRole { MenuId = 1,RoleId=1},
                    new MenuRole { MenuId = 2,RoleId=1},
                    new MenuRole { MenuId = 3,RoleId=1},
                    new MenuRole { MenuId = 4,RoleId=1},
                    new MenuRole { MenuId = 5,RoleId=1},
                });
                await _context.SaveChangesAsync();
            }

            if (!_context.Permissions.Any()) { // Verifica si hay registros antes de insertar
                { // Verifica si hay registros antes de insertar
                    _context.Permissions.AddRange(
                        new List<Permission>{
                        new Permission { Name = "Dashboard_Read", Slug = "1", Description = "Allows reading dashboard", State = "1", MenuId = 1 },
                        new Permission { Name = "Users_Read", Slug = "6", Description = "Allows reading users", State = "1", MenuId = 2 },
                        new Permission { Name = "Users_Write", Slug = "7", Description = "Allows writing users", State = "1", MenuId = 2 },
                        new Permission { Name = "Users_Delete", Slug = "8", Description = "Allows deleting users", State = "1", MenuId = 2 },
                        new Permission { Name = "Users_Update", Slug = "9", Description = "Allows updating users", State = "1", MenuId = 2 },
                        new Permission { Name = "Users_Create", Slug = "10", Description = "Allows creating users", State = "1", MenuId = 2 },
                        new Permission { Name = "Roles_Read", Slug = "11", Description = "Allows reading roles", State = "1", MenuId = 3 },
                        new Permission { Name = "Roles_Write", Slug = "12", Description = "Allows writing roles", State = "1", MenuId = 3 },
                        new Permission { Name = "Roles_Delete", Slug = "13", Description = "Allows deleting roles", State = "1", MenuId = 3 },
                        new Permission { Name = "Roles_Update", Slug = "14", Description = "Allows updating roles", State = "1", MenuId = 3 },
                        new Permission { Name = "Roles_Create", Slug = "15", Description = "Allows creating roles", State = "1", MenuId = 3 },
                        new Permission { Name = "Permissions_Read", Slug = "16", Description = "Allows reading permissions", State = "1", MenuId = 4 },
                        new Permission { Name = "Permissions_Write", Slug = "17", Description = "Allows writing permissions", State = "1", MenuId = 4 },
                        new Permission { Name = "Permissions_Delete", Slug = "18", Description = "Allows deleting permissions", State = "1", MenuId = 4 },
                        new Permission { Name = "Permissions_Update", Slug = "19", Description = "Allows updating permissions", State = "1", MenuId = 4 },
                        new Permission { Name = "Permissions_Create", Slug = "20", Description = "Allows creating permissions", State = "1", MenuId = 4 },
                        new Permission { Name = "Menus_Read", Slug = "21", Description = "Allows reading menus", State = "1", MenuId = 5 },
                        new Permission { Name = "Menus_Write", Slug = "22", Description = "Allows writing menus", State = "1", MenuId = 5 },
                        new Permission { Name = "Menus_Delete", Slug = "23", Description = "Allows deleting menus", State = "1", MenuId = 5 },
                        new Permission { Name = "Menus_Update", Slug = "24", Description = "Allows updating menus", State = "1", MenuId = 5 },
                        new Permission { Name = "Menus_Create", Slug = "25", Description = "Allows creating menus", State = "1", MenuId = 5 },
                    });
                    await _context.SaveChangesAsync();
                }


                if (!_context.RolePermissions.Any())
                { // Verifica si hay registros antes de insertar
                    _context.RolePermissions.AddRange(
                        new List<RolePermission>{
                        new RolePermission { RoleId = 1, PermissionId = 1, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 2, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 3, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 4, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 5, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 6, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 7, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 8, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 9, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 10, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 11, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 12, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 13, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 14, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 15, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 16, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 17, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 18, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 19, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 20, State="1" },
                        new RolePermission { RoleId = 1, PermissionId = 21, State="1" },
                        });
                    await _context.SaveChangesAsync();
                }

            }
        }
    }
}
