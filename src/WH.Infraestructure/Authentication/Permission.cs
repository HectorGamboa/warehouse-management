namespace WH.Infrastructure.Authentication
{
    public enum Permission
    {
        //Permisos Dashboard
        Dashboard_Read = 1,
        
        //Permisos Users
        Users_Read = 6,
        Users_Write = 7,
        Users_Delete = 8,
        Users_Update = 9,
        Users_Create = 10,

        //Permisos Roles
        Roles_Read = 11,
        Roles_Write = 12,
        Roles_Delete = 13,
        Roles_Update = 14,
        Roles_Create = 15,
        //Permisos para Permissions
        Permissions_Read = 16,
        Permissions_Write = 17,
        Permissions_Delete = 18,
        Permissions_Update = 19,
        Permissions_Create = 20,

        //Permisos Menus
        Menus_Read = 21,
        Menus_Write = 22,
        Menus_Delete = 23,
        Menus_Update = 24,
        Menus_Create = 25,
    }
}
