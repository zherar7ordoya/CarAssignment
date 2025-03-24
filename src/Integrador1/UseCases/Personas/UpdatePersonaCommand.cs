using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.UseCases.Commands;

namespace Integrador.UseCases.Personas;

public class UpdatePersonaCommand(Persona persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.UpdatePersona(persona)
            ? (true, null!)
            : (false, new Exception("Error al actualizar persona."));
    }

    public void Undo() { /* Lógica para deshacer */ }
}
