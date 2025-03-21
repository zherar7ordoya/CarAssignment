using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Entities;
using Integrador.Infrastructure.Persistence;

namespace Integrador.Infrastructure.Repositories;

public class PersonaRepository : Repository<Persona>
{
    public bool CreatePersona(Persona persona)
    {
        var personas = Read();
        persona.Id = personas.Count > 0 ? personas.Max(x => x.Id) + 1 : 1;

        if (Validator.Validate(persona, PersonaValidator.Validar))
        {
            Create(persona);
            return true;
        }
        else
        {
            ExceptionHandler.HandleException("Error al crear persona", new Exception("La persona no es válida"));
            return false;
        }
    }

    public bool UpdatePersona(Persona persona)
    {
        if (Validator.Validate(persona, PersonaValidator.Validar))
        {
            Update(persona);
            return true;
        }
        else
        {
            ExceptionHandler.HandleException("Error al actualizar persona", new Exception("La persona no es válida"));
            return false;
        }
    }

    public bool DeletePersona(Persona persona)
    {
        if (persona.Autos is null)
        {
            Update(persona);
            return true;
        }
        else
        {
            ExceptionHandler.HandleException("Error al eliminar persona", new Exception("No se puede eliminar la persona porque tiene autos asociados"));
            return false;
        }
    }

    public static List<Auto> GetListaAutos(Persona persona) => persona.Autos;

    public static int GetCantidadAutos(Persona persona) => persona.Autos.Count;

    public static decimal GetValorAutos(Persona persona) => persona.Autos.Sum(auto => auto.Precio);
}
