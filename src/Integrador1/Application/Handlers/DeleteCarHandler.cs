using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;

namespace Integrador.Application.Handlers;

public class DeleteCarHandler(
    IGenericRepository<Car> repository,
    IValidator<Car> validator) : IRequestHandler<DeleteCarCommand, bool>
{
    private readonly IGenericRepository<Car> _repository = repository;
    private readonly IValidator<Car> _validator = validator;

    public async Task<bool> Handle(DeleteCarCommand request, CancellationToken ct)
    {
        // Validación técnica con FluentValidation
        var validationResult = await _validator.ValidateAsync(request.Car, ct);

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

        return _repository.Delete(request.Car);
    }
}