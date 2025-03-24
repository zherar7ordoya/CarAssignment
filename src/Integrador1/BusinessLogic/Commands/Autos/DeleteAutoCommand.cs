using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Autos;

public class DeleteAutoCommand(Auto auto) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var personaRepository = new AutoRepository();
        return personaRepository.DeleteAuto(auto)
            ? (true, string.Empty)
            : (false, "Error al eliminar auto");
    }

    public void Undo() { /* Lógica para deshacer */ }
}
