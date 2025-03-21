using Integrador.Core;
using Integrador.CrossCutting;

namespace Integrador.BusinessLogic.Commands;

public class EliminarPersonaCommand(ViewController viewController, Persona persona) : ICommand
{
    private readonly ViewController _viewController = viewController;
    private readonly Persona _persona = persona;

    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() => _viewController.EliminarPersona(_persona));
        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer */ }
}
