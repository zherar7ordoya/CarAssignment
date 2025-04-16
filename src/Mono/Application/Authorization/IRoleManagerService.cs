namespace Integrador.Application.Authorization;

public interface IRoleManagerService
{
    void CreateRole(string roleName);
    void DeleteRole(string roleName);
    void AddPermissionToRole(string roleName, Permission permission);
    void RemovePermissionFromRole(string roleName, Permission permission);

    void AssignRoleToUser(string username, string roleName);
    void RemoveRoleFromUser(string username, string roleName);

    void AssignSpecialPermissionToUser(string username, Permission permission);
    void RemoveSpecialPermissionFromUser(string username, Permission permission);

    List<Role> GetAllRoles();
    List<Permission> GetPermissionsForRole(string roleName);
    List<Permission> GetAllPermissionsForUser(string username); // suma todo: roles + especiales
}

