using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.UseCases.Commands;

namespace Integrador.UseCases.Personas;

public class DeletePersonaCommand(Persona persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.DeletePersona(persona)
            ? (true, null!)
            : (false, new Exception("Error al eliminar persona."));
    }

    public void Undo() { /* Lógica para deshacer la eliminación (si es necesario) */ }
}
