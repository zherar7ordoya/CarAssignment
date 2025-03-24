using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Personas;

public class UpdatePersonaCommand(Persona persona) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.UpdatePersona(persona)
            ? (true, string.Empty)
            : (false, "Error al actualizar persona");
    }

    public void Undo() { /* Lógica para deshacer */ }
}
