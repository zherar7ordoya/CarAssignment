using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.Infrastructure;

namespace Integrador.UseCases.Autos;

public class UpdateAutoCommand(Auto auto) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (Validator.Validate(auto, AutoValidator.Validar))
        {
            var repository = new GenericRepository<Auto>();

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
