using Integrador.Entities;

using Integrador1.Entities;
using Integrador1.Persistence;

namespace Integrador1.Logic;

public class AutoManager : CRUD<Auto>
{
    public bool CrearAuto(string patente, string marca, string modelo, int año, decimal precio)
    {
        var auto = new Auto(patente, marca, modelo, año, precio);
        return ValidateAndCreate(auto, AutoValidator.Validar);
    }
}
