using Integrador.Abstractions;
using Integrador.Adapters.Persistence;
using Integrador.Entities;
using Integrador.Infrastructure;

namespace Integrador.UseCases.Personas;

public class CreatePersonaCommand(Persona persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (Validator.Validate(persona, PersonaValidator.Validar))
        {
            var repository = new GenericRepository<Persona>();
            var personas = repository.Read();
            persona.Id = personas.Count > 0 ? personas.Max(x => x.Id) + 1 : 1;

            return repository.Create(persona)
                ? (true, null!)
                : (false, new Exception("Error al crear persona."));
        }
        else
        {
            var exception = new Exception("La persona no es válida");
            ExceptionHandler.HandleException("Error al crear persona", exception);
            return (false, exception);
        }
    }

    public void Undo() { /* Lógica para deshacer */ }
}
