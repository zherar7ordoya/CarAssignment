using CarAssignment.Application.Security.Core;

namespace CarAssignment.Application.Security.Contracts;

public interface IAuthorizationService
{
    bool HasPermission(string username, Permission permission);
    List<Permission> GetPermissions(string username);
}
