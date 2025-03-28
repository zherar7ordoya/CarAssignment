using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Validators;

namespace Integrador.Application.Commands;

public class CreateCarCommand(Car auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (Validator.Validate(auto, CarValidator.Validar))
        {
            var repository = new GenericRepository<Car>();
            var autos = repository.Read();
            auto.Id = autos.Count > 0 ? autos.Max(x => x.Id) + 1 : 1;

            return repository.Create(auto)
                ? (true, null!)
                : (false, new Exception("Error al crear auto."));
        }
        else
        {
            var exception = new Exception("El auto no es válido");
            ExceptionHandler.HandleException("Error al crear auto", exception);
            return (false, exception);
        }
    }

    public void Undo() { /* Lógica para deshacer */ }
}
