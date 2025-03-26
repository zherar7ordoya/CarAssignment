using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.Infrastructure;

namespace Integrador.UseCases.Autos;

public class DeleteAutoCommand(Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (auto.DueñoId == 0)
        {
            var repository = new GenericRepository<Auto>();

            return repository.Delete(auto)
                ? (true, null!)
                : (false, new Exception("Error al eliminar auto."));
        }
        else
        {
            var exception = new Exception("No se puede eliminar el auto porque tiene dueño");
            ExceptionHandler.HandleException("Error al eliminar auto", exception);
            return (false, exception);
        }
    }

    public void Undo() { /* Lógica para deshacer */ }
}
