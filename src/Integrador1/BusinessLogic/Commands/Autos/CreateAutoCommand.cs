using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Autos;

public class CreateAutoCommand(Auto auto) : ICommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() =>
        (
            new AutoRepository().CreateAuto(auto)
        ));

        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer */ }
}
