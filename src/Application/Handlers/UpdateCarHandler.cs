using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class UpdateCarHandler(
    IGenericRepository<Car> repository,
    IValidator<Car> validator) : IRequestHandler<UpdateCarCommand, bool>
{
    private readonly IGenericRepository<Car> _repository = repository;
    private readonly IValidator<Car> _validator = validator;

    public async Task<bool> Handle(UpdateCarCommand request, CancellationToken ct)
    {
        // 1. Validación Técnica (formato de patente, año, etc.)
        var validationResult = await _validator.ValidateAsync(request.Car, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // 2. Validación de Negocio (ej: verificar si el auto existe)
        var existingCar = _repository.GetByIdAsync(request.Car.Id, ct) ?? throw new DomainException("El auto no existe.");

        // 3. Actualizar entidad
        return await _repository.UpdateAsync(request.Car, ct);
    }
}
