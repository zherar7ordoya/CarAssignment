using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Personas;

public class CreatePersonaCommand(Persona persona) : ICommand
{
    private readonly PersonaRepository _personaRepository = new();

    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() =>
        (
            _personaRepository.CreatePersona(persona))
        );
        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer */ }
}
