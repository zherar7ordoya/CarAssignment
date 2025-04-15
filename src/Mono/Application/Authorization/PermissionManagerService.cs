using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public class PermissionManagerService
(
    IUserRepository userRepository,
    IRoleRepository roleRepository
) : IPermissionManagerService
{
    public void CreateRole(string roleName)
    {
        if (roleRepository.GetByName(roleName) != null)
            throw new InvalidOperationException("Role already exists.");

        var newRole = new Role(roleName, []);
        roleRepository.Save(newRole);
    }

    public void DeleteRole(string roleName)
    {
        roleRepository.Delete(roleName);

        // Además, remover el rol de los usuarios que lo tuvieran
        var users = userRepository.GetAll();
        foreach (var user in users)
        {
            if (user.RoleNames.Remove(roleName)) // No need to check Contains before Remove
            {
                userRepository.Update(user);
            }
        }
    }

    public void AddPermissionToRole(string roleName, Permission permission)
    {
        var role = roleRepository.GetByName(roleName)
                   ?? throw new InvalidOperationException("Role not found.");

        if (!role.Permissions.Contains(permission))
        {
            role.Permissions.Add(permission);
            roleRepository.Save(role);
        }
    }

    public void RemovePermissionFromRole(string roleName, Permission permission)
    {
        var role = roleRepository.GetByName(roleName)
                   ?? throw new InvalidOperationException("Role not found.");

        if (role.Permissions.Remove(permission))
        {
            roleRepository.Save(role);
        }
    }

    public void AssignRoleToUser(string username, string roleName)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (!user.RoleNames.Contains(roleName))
        {
            user.RoleNames.Add(roleName);
            userRepository.Update(user);
        }
    }

    public void RemoveRoleFromUser(string username, string roleName)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (user.RoleNames.Remove(roleName)) // No need to check Contains before Remove
        {
            userRepository.Update(user);
        }
    }

    public void AssignSpecialPermissionToUser(string username, Permission permission)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (!user.SpecialPermissions.Contains(permission))
        {
            user.SpecialPermissions.Add(permission);
            userRepository.Update(user);
        }
    }

    public void RemoveSpecialPermissionFromUser(string username, Permission permission)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (user.SpecialPermissions.Remove(permission)) // No need to check Contains before Remove
        {
            userRepository.Update(user);
        }
    }

    public List<Role> GetAllRoles()
    {
        return roleRepository.GetAll();
    }

    public List<Permission> GetPermissionsForRole(string roleName)
    {
        return roleRepository.GetByName(roleName)?.Permissions ?? [];
    }

    public List<Permission> GetAllPermissionsForUser(string username)
    {
        var user = userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        var permissions = new HashSet<Permission>();

        foreach (var roleName in user.RoleNames)
        {
            var role = roleRepository.GetByName(roleName);
            if (role != null)
            {
                foreach (var p in role.Permissions)
                    permissions.Add(p);
            }
        }

        foreach (var special in user.SpecialPermissions)
            permissions.Add(special);

        return [.. permissions];
    }
}

