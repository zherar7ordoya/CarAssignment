using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Infrastructure.Repositories;

public class AutoRepository : Repository<Auto>
{
    public bool CreateAuto(string patente,
                           string marca,
                           string modelo,
                           int año,
                           decimal precio)
    {
        var auto = new Auto(patente, marca, modelo, año, precio);

        if (Validator.Validate(auto, AutoValidator.Validar))
        {
            Create(auto);
            return true;
        }

        return false;
    }

    public List<Auto> ReadDisponibles()
    {
        return [.. Read().Where(auto => auto.DueñoId == 0)];
    }
}
