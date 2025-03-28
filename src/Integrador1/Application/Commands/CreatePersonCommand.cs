using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Entities;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Validators;

namespace Integrador.Application.Commands;

public class CreatePersonCommand(Person persona) : ICommand
{
    public (bool Success, Exception Error) Execute()
    {
        if (GenericValidator.Validate(persona, PersonValidator.Validar))
        {
            var repository = new GenericRepository<Person>();
            var personas = repository.GetAll();
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
