using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.UseCases.Commands;

namespace Integrador.UseCases.Autos;

public class DeleteAutoCommand(Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        var autoRepository = new AutoRepository();
        return autoRepository.DeleteAuto(auto)
            ? (true, null!)
            : (false, new Exception("Error al eliminar auto"));
    }

    public void Undo() { /* Lógica para deshacer */ }
}
