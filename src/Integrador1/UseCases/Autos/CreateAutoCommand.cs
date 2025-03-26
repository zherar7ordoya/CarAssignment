using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Autos;

public class CreateAutoCommand(Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        var autoRepository = new AutoRepository();
        return autoRepository.CreateAuto(auto)
            ? (true, null!)
            : (false, new Exception("Error al crear auto."));
    }

    public void Undo() { /* Lógica para deshacer */ }
}
