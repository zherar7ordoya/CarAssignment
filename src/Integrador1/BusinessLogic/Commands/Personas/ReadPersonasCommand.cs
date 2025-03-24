using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Personas;

public class ReadPersonasCommand : IReadCommand<List<Persona>>
{
    public (bool Success, List<Persona>? Result, string ErrorMessage) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.Read() is List<Persona> personas
            ? (true, personas, string.Empty)
            : (false, null, "Error al listar personas");
    }

    public void Undo() { }
}
