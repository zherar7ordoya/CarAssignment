using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using FluentValidation;
using Integrador.Application.Interfaces;
using Integrador.Application.DTOs;

namespace Integrador.Application.Handlers;

public class CreatePersonHandler
(
    IGenericRepository<Person> repository,
    IValidator<Person> validator
) : IRequestHandler<CreatePersonCommand, Unit>
{
    public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken ct)
    {
        // Convertimos el DTO a la entidad correspondiente
        var personEntity = new Person
        (
            request.PersonDTO.Nombre,
            request.PersonDTO.Apellido,
            request.PersonDTO.DNI
        );

        // Validación de la entidad Person
        var validation = await validator.ValidateAsync(personEntity, ct);

        if (!validation.IsValid)
        {
            var errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // Persistimos la entidad Person
        await repository.CreateAsync(personEntity, ct);

        return Unit.Value;
    }
}
