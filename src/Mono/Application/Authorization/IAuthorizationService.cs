using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public interface IAuthorizationService
{
    bool HasPermission(string username, Permission permission);
    List<Permission> GetEffectivePermissions(string username);
}

