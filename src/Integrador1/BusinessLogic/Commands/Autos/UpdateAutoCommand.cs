using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Autos;

public class UpdateAutoCommand(Auto auto) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var personaRepository = new AutoRepository();
        return personaRepository.UpdateAuto(auto)
            ? (true, string.Empty)
            : (false, "Error al actualizar auto");
    }

    public void Undo() { /* Lógica para deshacer */ }
}
