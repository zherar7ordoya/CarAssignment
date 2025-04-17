using Integrador.Application.Security.Core;

namespace Integrador.Application.Security.Contracts;

public interface IAuthorizationService
{
    bool HasPermission(string username, Permission permission);
    List<Permission> GetPermissions(string username);
}
