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

    public void Execute() => _viewController.CrearPersona(_dni, _nombre, _apellido);
    public void Undo() { /* Lógica para deshacer */ }
}
