using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Application.Validators;
using Integrador.Shared.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using FluentValidation;

namespace Integrador.Application.Handlers;

public class CreatePersonHandler(
    IGenericRepository<Person> repository,
    IValidator<Person> validator) : IRequestHandler<CreatePersonCommand, bool>
{
    private readonly IGenericRepository<Person> _repository = repository;
    private readonly IValidator<Person> _validator = validator;

    public async Task<bool> Handle(CreatePersonCommand request, CancellationToken ct)
    {
        // Validación asíncrona
        var validationResult = await _validator.ValidateAsync(request.Person, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        // Crear persona (retorna booleano)
        return _repository.Create(request.Person);
    }
}