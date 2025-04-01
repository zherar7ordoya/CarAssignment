using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
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
        // 1. Validación Técnica (formato de patente, año, etc.)
        var validationResult = await validator.ValidateAsync(request.Car, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // 2. Validación de Negocio (ej: verificar si el auto existe)
        var existingCar = repository.GetByIdAsync(request.Car.Id, ct) ?? throw new DomainException("El auto no existe.");

        // 3. Actualizar entidad
        await repository.UpdateAsync(request.Car, ct);

        return Unit.Value;
    }
}
