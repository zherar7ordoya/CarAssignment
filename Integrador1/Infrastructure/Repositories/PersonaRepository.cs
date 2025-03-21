using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Infrastructure.Repositories;

public class PersonaRepository : Repository<Persona>
{
    public bool CreatePersona(string dni,
                              string nombre,
                              string apellido)
    {
        var persona = new Persona(dni, nombre, apellido);

        if (Validator.Validate(persona, PersonaValidator.Validar))
        {
            Create(persona);
            return true;
        }

        return false;
    }

    public static List<Auto> GetListaAutos(Persona persona) => persona.Autos;

    public static int GetCantidadAutos(Persona persona) => persona.Autos.Count;

    public static decimal GetValorAutos(Persona persona) => persona.Autos.Sum(auto => auto.Precio);
}
