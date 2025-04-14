namespace Integrador.Application.Interfaces;

public interface IPermissionService
{
    bool CanDeleteEntities();
    // podemos sumar más luego: CanEditEntities(), CanViewReports(), etc.
}
