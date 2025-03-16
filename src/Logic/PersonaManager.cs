using Integrador.Entities;
using Integrador.Persistence;

namespace Integrador.Logic;

public class PersonaManager : CRUD<Persona>
{
    public bool CrearPersona(string dni, string nombre, string apellido)
    {
        var persona = new Persona(dni, nombre, apellido);
        return ValidateAndCreate(persona, PersonaValidator.Validar);
    }

    public static List<Auto> GetListaAutos(Persona persona) => persona.Autos;

    public static int GetCantidadAutos(Persona persona) => persona.Autos.Count;

    public static decimal GetValorAutos(Persona persona) => persona.Autos.Sum(auto => auto.Precio);
}
