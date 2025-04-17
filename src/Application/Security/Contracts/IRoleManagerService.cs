using Integrador.Application.Security.Core;

namespace Integrador.Application.Security.Contracts;

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

    List<Role> GetRoles();
    List<Permission> GetPermissions();
    List<Permission> GetPermissionsForRole(string roleName);
    List<Permission> GetPermissionsForUser(string username); // suma todo: roles + especiales
}

