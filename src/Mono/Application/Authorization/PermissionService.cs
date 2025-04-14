using Integrador.Application.Interfaces;
using Integrador.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public class PermissionService(IAuthService authService) : IPermissionService
{
    public bool CanDeleteEntities()
    {
        var user = authService.GetCurrentUser();
        return user?.Role == Role.Admin;
    }

    // otros permisos pueden ir aquí
}

