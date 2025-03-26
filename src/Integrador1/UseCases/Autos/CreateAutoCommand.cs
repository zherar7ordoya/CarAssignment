using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.Infrastructure;

namespace Integrador.UseCases.Autos;

public class CreateAutoCommand(Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (Validator.Validate(auto, AutoValidator.Validar))
        {
            var repository = new GenericRepository<Auto>();
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
