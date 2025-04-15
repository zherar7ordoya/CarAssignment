using Integrador.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public class AuthorizationService
(
    IUserRepository userRepository,
    IRoleRepository roleRepository
) : IAuthorizationService
{
    public bool HasPermission(string username, Permission permission)
    {
        var user = userRepository.GetByUsername(username);
        if (user == null) return false;

        if (user.SpecialPermissions.Contains(permission)) return true;

        foreach (var roleName in user.RoleNames)
        {
            var role = roleRepository.GetByName(roleName);
            if (role != null && role.Permissions.Contains(permission))
                return true;
        }

        return false;
    }

    public List<Permission> GetEffectivePermissions(string username)
    {
        var user = userRepository.GetByUsername(username);
        if (user == null) return [];

        var result = new HashSet<Permission>(user.SpecialPermissions);

        foreach (var roleName in user.RoleNames)
        {
            var role = roleRepository.GetByName(roleName);
            if (role != null)
                foreach (var permission in role.Permissions)
                    result.Add(permission);
        }

        return [.. result];
    }
}
