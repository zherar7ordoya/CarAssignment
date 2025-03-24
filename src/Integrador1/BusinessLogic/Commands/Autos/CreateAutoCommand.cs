using Integrador.Core;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Autos;

public class CreateAutoCommand(Auto auto) : IWriteCommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var personaRepository = new AutoRepository();
        return personaRepository.CreateAuto(auto)
            ? (true, string.Empty)
            : (false, "Error al crear auto");
    }

    public void Undo() { /* Lógica para deshacer */ }
}
