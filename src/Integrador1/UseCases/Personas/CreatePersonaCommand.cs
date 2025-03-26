using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Personas;

public class CreatePersonaCommand(Persona persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        var personaRepository = new PersonaRepository();
        return personaRepository.CreatePersona(persona)
            ? (true, null!)
            : (false, new Exception("Error al crear persona."));
    }

    public void Undo() { /* Lógica para deshacer */ }
}
