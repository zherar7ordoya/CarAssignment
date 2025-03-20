using Integrador.Core;

namespace Integrador.BusinessLogic.Commands;

public class ActualizarAutoCommand(ViewController viewController, Auto auto) : ICommand
{
    private readonly ViewController _viewController = viewController;
    private readonly Auto _auto = auto;

    public void Execute() => _viewController.ActualizarAuto(_auto);
    public void Undo() { /* Lógica para deshacer */ }
}
