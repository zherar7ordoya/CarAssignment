namespace Integrador.Application.Authorization;

public interface IAuthorizationService
{
    bool HasPermission(string username, Permission permission);
    List<Permission> GetPermissions(string username);
}

