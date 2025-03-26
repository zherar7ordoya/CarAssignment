using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;

namespace Integrador.UseCases.Autos;

public class UpdateAutoCommand(Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        var autoRepository = new AutoRepository();
        return autoRepository.UpdateAuto(auto)
            ? (true, null!)
            : (false, new Exception("Error al actualizar auto"));
    }

    public void Undo() { /* Lógica para deshacer */ }
}
