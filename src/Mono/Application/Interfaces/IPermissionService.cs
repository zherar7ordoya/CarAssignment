using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Interfaces;

public interface IPermissionService
{
    bool CanDeleteEntities();
    // podemos sumar más luego: CanEditEntities(), CanViewReports(), etc.
}
