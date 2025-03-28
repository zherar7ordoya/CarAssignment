using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;

namespace Integrador.Application.Commands;

public class DeletePersonCommand(Person persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (persona.Autos is null)
        {
            var repository = new GenericRepository<Person>();

            return repository.Delete(persona)
                ? (true, null!)
                : (false, new Exception("Error al eliminar persona."));
        }
        else
        {
            var exception = new Exception("No se puede eliminar la persona porque tiene autos asociados.");
            ExceptionHandler.HandleException("Error al eliminar persona", exception);
            return (false, exception);
        }
    }

    public void Undo() { /* Lógica para deshacer la eliminación (si es necesario) */ }
}
