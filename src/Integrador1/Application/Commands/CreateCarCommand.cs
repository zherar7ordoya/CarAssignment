using Integrador.Application.Interfaces;
using Integrador.Application.Validators;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Persistence;
using Integrador.Shared.Exceptions;

namespace Integrador.Application.Commands;

public class CreateCarCommand(Car auto, IGenericRepository<Car> repository, IValidator<Car> validator) : ICommand
{
    private readonly IValidator<Car> _validator = validator;

    public (bool Success, Exception Error) Execute()
    {
        var validationResult = _validator.Validate(auto);

        if (!validationResult.IsValid)
        {
            return (false, new DomainException(string.Join(", ", validationResult.Errors)));
        }

        var autos = repository.GetAll();
        auto.Id = autos.Count > 0 ? autos.Max(x => x.Id) + 1 : 1;

        return repository.Create(auto)
            ? (true, null!)
            : (false, new Exception("Error al crear auto."));

    }

    public void Undo() { /* Lógica para deshacer */ }
}
