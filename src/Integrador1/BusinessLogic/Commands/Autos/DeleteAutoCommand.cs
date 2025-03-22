using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador.BusinessLogic.Commands.Autos;

public class DeleteAutoCommand(Auto auto) : ICommand
{
    public (bool Success, string ErrorMessage) Execute()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() =>
        (
            new AutoRepository().DeleteAuto(auto)
        ));

        return (Success, ErrorMessage);
    }

    public void Undo() { /* Lógica para deshacer */ }
}
