using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using FluentValidation;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class CreatePersonHandler
(
    IGenericRepository<Person> repository,
    IValidator<Person> validator
) : IRequestHandler<CreatePersonCommand, Unit>
{
    public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken ct)
    {
        // Validación asíncrona
        var validationResult = await validator.ValidateAsync(request.Person, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // Crear persona (retorna booleano)
        await repository.CreateAsync(request.Person, ct);

        return Unit.Value;
    }
}