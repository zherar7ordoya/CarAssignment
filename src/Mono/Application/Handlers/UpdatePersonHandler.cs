using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class UpdatePersonHandler
(
    IGenericRepository<Person> repository,
    IValidator<Person> validator
) : IRequestHandler<UpdatePersonCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken ct)
    {
        // 1. Validación Técnica (FluentValidation)
        var validationResult = await validator.ValidateAsync(request.Person, ct);

        if (!validationResult.IsValid)
        {
            throw new DomainException([.. validationResult.Errors.Select(e => e.ErrorMessage)]);
        }

        // 2. Verificar existencia
        var existingPerson = repository.GetByIdAsync(request.Person.Id, ct) ?? throw new DomainException("La persona no existe.");

        // 3. Actualizar entidad
        await repository.UpdateAsync(request.Person, ct);

        return Unit.Value;
    }
}
