using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;

namespace Integrador.Application.Commands;

public class DeleteCarCommand(Car auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (auto.DueñoId == 0)
        {
            var repository = new GenericRepository<Car>();

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
