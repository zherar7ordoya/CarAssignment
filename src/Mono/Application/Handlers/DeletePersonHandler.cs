using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class DeletePersonHandler(
    IGenericRepository<Person> repository,
    IValidator<Person> validator) : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IGenericRepository<Person> _repository = repository;
    private readonly IValidator<Person> _validator = validator; // Inyectamos el validador

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken ct)
    {
        // 1. Validación Técnica con FluentValidation
        var validationResult = await _validator.ValidateAsync(request.Person, ct);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // 2. Validación de Negocio: No permitir eliminar si hay autos asociados
        if (request.Person.HasCars())
        {
            throw new DomainException("No se puede eliminar una persona que tiene autos asociados");
        }

        // 3. Eliminar la persona
        return await _repository.DeleteAsync(request.Person, ct);
    }
}