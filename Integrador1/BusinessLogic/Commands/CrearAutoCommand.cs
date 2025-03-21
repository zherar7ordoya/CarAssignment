using Integrador.CrossCutting;

namespace Integrador.BusinessLogic.Commands;

public class CrearAutoCommand(ViewController viewController,
                              string patente,
                              string marca,
                              string modelo,
                              int año,
                              decimal precio) : ICommand
{
    private readonly ViewController _viewController = viewController;
    private readonly string _patente = patente;
    private readonly string _marca = marca;
    private readonly string _modelo = modelo;
    private readonly int _año = año;
    private readonly decimal _precio = precio;

    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() => _viewController.CreateAuto(_patente, _marca, _modelo, _año, _precio));
        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer */ }
}
