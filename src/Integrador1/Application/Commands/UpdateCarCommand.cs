using Integrador.Application.Interfaces;
using Integrador.Application.Validators;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Validators;

namespace Integrador.Application.Commands;

public class UpdateCarCommand(Car auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (GenericValidator.Validate(auto, CarValidator.Validar))
        {
            var repository = new GenericRepository<Car>();

            return repository.Update(auto)
                ? (true, null!)
                : (false, new Exception("Error al actualizar auto."));
        }
        else
        {
            var exception = new Exception("El auto no es válido");
            ExceptionHandler.HandleException("Error al actualizar auto", exception);
            return (false, exception);
        }
    }

    public void Undo() { /* Lógica para deshacer */ }
}
