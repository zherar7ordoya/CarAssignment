using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class UpdateCarHandler
(
    IGenericRepository<Car> repository,
    IValidator<Car> validator
) : IRequestHandler<UpdateCarCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken ct)
    {
        // Convertir el DTO en la entidad correspondiente
        var carEntity = new Car(
            request.CarDTO.Patente,
            request.CarDTO.Marca,
            request.CarDTO.Modelo,
            request.CarDTO.Año,
            request.CarDTO.Precio
        )
        { Id = request.CarDTO.Id }; // Asignamos el ID

        // 1. Validación Técnica (formato de patente, año, etc.)
        var validation = await validator.ValidateAsync(carEntity, ct);

        if (!validation.IsValid)
        {
            var errors = string.Join("", validation.Errors.Select(e => e.ErrorMessage).ToList());
            throw new ApplicationException(errors);
        }

        // 2. Validación de Negocio (ej: verificar si el auto existe)
        var existingCar = await repository.GetByIdAsync(carEntity.Id, ct) ?? throw new ApplicationException("El auto no existe.");

        // 3. Actualizar entidad
        await repository.UpdateAsync(carEntity, ct);

        return Unit.Value;
    }
}
