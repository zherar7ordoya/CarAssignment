using Integrador.Core;

namespace Integrador.BusinessLogic.Commands;

public class ActualizarPersonaCommand(ViewController viewController, Persona persona) : ICommand
{
    private readonly ViewController _viewController = viewController;
    private readonly Persona _persona = persona;

    public void Execute() => _viewController.ActualizarPersona(_persona);
    public void Undo() { /* Lógica para deshacer */ }
}
