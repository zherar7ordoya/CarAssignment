using Integrador.CrossCutting;

namespace Integrador.BusinessLogic.Commands;

public class CrearPersonaCommand(ViewController viewController,
                                 string dni,
                                 string nombre,
                                 string apellido) : ICommand
{
    private readonly ViewController _viewController = viewController;
    private readonly string _dni = dni;
    private readonly string _nombre = nombre;
    private readonly string _apellido = apellido;

    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() => _viewController.CrearPersona(_dni, _nombre, _apellido));
        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer */ }
}
