using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.DTOs;
using Integrador.Domain.Exceptions;
using FluentValidation;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class CreateCarHandler
(
    IGenericRepository<Car> repository,
    IValidator<Car> validator
) : IRequestHandler<CreateCarCommand, Unit>
{
    public async Task<Unit> Handle(CreateCarCommand request, CancellationToken ct)
    {
        // Convertimos el DTO a la entidad correspondiente
        var carEntity = new Car
        (
            request.CarDTO.Patente,
            request.CarDTO.Marca,
            request.CarDTO.Modelo,
            request.CarDTO.Año,
            request.CarDTO.Precio
        );

        // Validamos la entidad Car
        var validation = await validator.ValidateAsync(carEntity, ct);

        if (!validation.IsValid)
        {
            var errors = string.Join(", ", validation.Errors.Select(e => e.ErrorMessage));
            throw new ApplicationException(errors);
        }

        // Persistimos la entidad Car
        await repository.CreateAsync(carEntity, ct);

        return Unit.Value;
    }
}
