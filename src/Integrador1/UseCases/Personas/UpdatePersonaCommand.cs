using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.Infrastructure;

namespace Integrador.UseCases.Personas;

public class UpdatePersonaCommand(Persona persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (Validator.Validate(persona, PersonaValidator.Validar))
        {
            var repository = new GenericRepository<Persona>();

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
