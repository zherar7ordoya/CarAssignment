using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Personas;

public class DeletePersonaCommand(PersonaRepository personaRepository, Persona persona) : ICommand
{
    private readonly PersonaRepository _personaRepository = personaRepository;
    private readonly Persona _persona = persona;

    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() => _personaRepository.Delete(_persona));
        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer la eliminación (si es necesario) */ }
}
