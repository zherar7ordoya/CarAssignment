using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;

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
        var existingCar = _repository.GetById(request.Car.Id) ?? throw new DomainException("El auto no existe.");

        // 3. Actualizar entidad
        return _repository.Update(request.Car);
    }
}
