using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Application.Interfaces;
using Integrador.Application.DTOs;  // Asegúrate de importar el namespace de DTOs

namespace Integrador.Application.Handlers;

public class UpdatePersonHandler
(
    IGenericRepository<Person> repository,
    IValidator<Person> validator
) : IRequestHandler<UpdatePersonCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken ct)
    {
        // 1. Convertir DTO a Entidad Person
        var personEntity = new Person
        (
            request.PersonDTO.Id,
            request.PersonDTO.DNI,
            request.PersonDTO.Nombre,
            request.PersonDTO.Apellido,
            [.. request.PersonDTO.Autos.Select(auto => new Car
            (
                auto.Patente,
                auto.Marca,
                auto.Modelo,
                auto.Año,
                auto.Precio
            ))]
        );

        // 2. Validación Técnica (FluentValidation)
        var validation = await validator.ValidateAsync(personEntity, ct);

        if (!validation.IsValid)
        {
            var errors = string.Join("", validation.Errors.Select(e => e.ErrorMessage).ToList());
            throw new ApplicationException(errors);
        }

        // 3. Verificar existencia
        var existingPerson = await repository.GetByIdAsync(request.PersonDTO.Id, ct) ?? throw new ApplicationException("La persona no existe.");

        // 4. Actualizar entidad
        await repository.UpdateAsync(personEntity, ct);

        return Unit.Value;
    }
}
