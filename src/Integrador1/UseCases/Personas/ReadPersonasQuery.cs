using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Personas;

public class ReadPersonasQuery : IReadQuery<List<Persona>>
{
    public (bool Success, List<Persona>? Result, Exception Error) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.Read() is List<Persona> personas
            ? (true, personas, null!)
            : (false, null, new Exception("Error al listar personas."));
    }

    public void Undo() { }
}
