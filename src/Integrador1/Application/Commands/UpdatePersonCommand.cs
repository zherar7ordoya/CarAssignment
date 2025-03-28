using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Validators;

namespace Integrador.Application.Commands;

public class UpdatePersonCommand(Person persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (GenericValidator.Validate(persona, PersonValidator.Validar))
        {
            var repository = new GenericRepository<Person>();

            return repository.Update(persona)
                ? (true, null!)
                : (false, new Exception("Error al actualizar persona."));
        }
        else
        {
            var exception = new Exception("La persona no es válida");
            ExceptionHandler.HandleException("Error al actualizar persona", exception);
            return (false, exception);
        }
    }

    public void Undo() { /* Lógica para deshacer */ }
}
