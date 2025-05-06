using CarAssignment.Application.Security.Contracts;
using CarAssignment.Application.Security.Core;
using CarAssignment.Presentation.Composition;

namespace CarAssignment.Application.Security.Services;

public class RoleManagerService() : IRoleManagerService
{
    private readonly IUserRepository _userRepository = AppServiceProvider.GetService<IUserRepository>();
    private readonly IRoleRepository _roleRepository = AppServiceProvider.GetService<IRoleRepository>();

    public void CreateRole(string roleName)
    {
        if (_roleRepository.GetByName(roleName) != null)
            throw new InvalidOperationException("Role already exists.");

        var newRole = new Role(roleName, []);
        _roleRepository.Save(newRole);
    }

    public void DeleteRole(string roleName)
    {
        _roleRepository.Delete(roleName);

        // Además, remover el rol de los usuarios que lo tuvieran
        var users = _userRepository.ReadAll();
        foreach (var user in users)
        {
            if (user.RoleNames.Remove(roleName)) // No need to check Contains before Remove
            {
                _userRepository.Update(user);
            }
        }
    }

    public void AddPermissionToRole(string roleName, Permission permission)
    {
        var role = _roleRepository.GetByName(roleName)
                   ?? throw new InvalidOperationException("Role not found.");

        if (!role.Permissions.Contains(permission))
        {
            role.Permissions.Add(permission);
            _roleRepository.Save(role);
        }
    }

    public void RemovePermissionFromRole(string roleName, Permission permission)
    {
        var role = _roleRepository.GetByName(roleName)
                   ?? throw new InvalidOperationException("Role not found.");

        if (role.Permissions.Remove(permission))
        {
            _roleRepository.Save(role);
        }
    }

    public void AssignRoleToUser(string username, string roleName)
    {
        var user = _userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (!user.RoleNames.Contains(roleName))
        {
            user.RoleNames.Add(roleName);
            _userRepository.Update(user);
        }
    }

    public void RemoveRoleFromUser(string username, string roleName)
    {
        var user = _userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (user.RoleNames.Remove(roleName)) // No need to check Contains before Remove
        {
            _userRepository.Update(user);
        }
    }

    public void AssignSpecialPermissionToUser(string username, Permission permission)
    {
        var user = _userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (!user.SpecialPermissions.Contains(permission))
        {
            user.SpecialPermissions.Add(permission);
            _userRepository.Update(user);
        }
    }

    public void RemoveSpecialPermissionFromUser(string username, Permission permission)
    {
        var user = _userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        if (user.SpecialPermissions.Remove(permission)) // No need to check Contains before Remove
        {
            _userRepository.Update(user);
        }
    }

    public List<Role> GetRoles()
    {
        return _roleRepository.GetAll();
    }

    public List<Permission> GetPermissionsForRole(string roleName)
    {
        return _roleRepository.GetByName(roleName)?.Permissions ?? [];
    }

    public List<Permission> GetPermissionsForUser(string username)
    {
        var user = _userRepository.GetByUsername(username)
                   ?? throw new InvalidOperationException("User not found.");

        var permissions = new HashSet<Permission>();

        foreach (var roleName in user.RoleNames)
        {
            var role = _roleRepository.GetByName(roleName);
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

    public List<Permission> GetPermissions()
    {
        return [.. KnownPermissions.All];
    }
}
