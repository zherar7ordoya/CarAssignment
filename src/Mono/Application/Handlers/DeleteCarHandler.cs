﻿using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class DeleteCarHandler
(
    IGenericRepository<Car> repository,
    IValidator<Car> validator
) : IRequestHandler<DeleteCarCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken ct)
    {
        // Validación técnica con FluentValidation
        var validationResult = await validator.ValidateAsync(request.Car, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // Validación de negocio
        if (request.Car.HasOwner())
        {
            throw new DomainException("No se puede eliminar un auto que tiene dueño");
        }

        await repository.DeleteAsync(request.Car, ct);

        return Unit.Value;
    }
}
