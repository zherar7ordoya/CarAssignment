using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Personas;

public class CreatePersonaCommand(Persona persona) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.CreatePersona(persona)
            ? (true, string.Empty)
            : (false, "Error al crear persona");
    }

    public void Undo() { /* Lógica para deshacer */ }
}
