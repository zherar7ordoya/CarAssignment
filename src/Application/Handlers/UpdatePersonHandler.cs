using MediatR;
using Integrador.Domain.Entities;
using FluentValidation;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class UpdatePersonHandler(
    IGenericRepository<Person> repository,
    IValidator<Person> validator) : IRequestHandler<UpdatePersonCommand, bool>
{
    private readonly IGenericRepository<Person> _repository = repository;
    private readonly IValidator<Person> _validator = validator;

    public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken ct)
    {
        // 1. Validación Técnica (FluentValidation)
        var validationResult = await _validator.ValidateAsync(request.Person, ct);

        if (!validationResult.IsValid)
        {
            throw new DomainException([.. validationResult.Errors.Select(e => e.ErrorMessage)]);
        }

        // 2. Verificar existencia
        var existingPerson = _repository.GetByIdAsync(request.Person.Id, ct) ?? throw new DomainException("La persona no existe.");

        // 3. Actualizar entidad
        return await _repository.UpdateAsync(request.Person, ct);
    }
}
