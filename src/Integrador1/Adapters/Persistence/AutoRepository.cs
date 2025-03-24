using Integrador.CrossCutting;
using Integrador.Entities;

namespace Integrador.Adapters.Persistence;

public class AutoRepository : GenericRepository<Auto>
{
    public bool CreateAuto(Auto auto)
    {
        var autos = Read();
        auto.Id = autos.Count > 0 ? autos.Max(x => x.Id) + 1 : 1;

        if (Validator.Validate(auto, AutoValidator.Validar))
        {
            Create(auto);
            return true;
        }
        else
        {
            ExceptionHandler.HandleException("Error al crear auto", new Exception("El auto no es válido"));
            return false;
        }
    }

    public bool UpdateAuto(Auto auto)
    {
        if (Validator.Validate(auto, AutoValidator.Validar))
        {
            Update(auto);
            return true;
        }
        else
        {
            ExceptionHandler.HandleException("Error al modificar auto", new Exception("El auto no es válido"));
            return false;
        }
    }

    public bool DeleteAuto(Auto auto)
    {
        if (auto.DueñoId == 0)
        {
            Delete(auto);
            return true;
        }
        else
        {
            ExceptionHandler.HandleException("Error al eliminar auto", new Exception("No se puede eliminar el auto porque tiene dueño"));
            return false;
        }
    }

    public List<Auto> ReadDisponibles()
    {
        return [.. Read().Where(auto => auto.DueñoId == 0)];
    }
}
