using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Personas;

public class DeletePersonaCommand(Persona persona) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.DeletePersona(persona)
            ? (true, string.Empty)
            : (false, "Error al eliminar persona");
    }

    public void Undo() { /* Lógica para deshacer la eliminación (si es necesario) */ }
}
