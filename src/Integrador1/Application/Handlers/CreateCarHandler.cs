using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using FluentValidation;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class CreateCarHandler(
    IGenericRepository<Car> repository,
    IValidator<Car> validator) : IRequestHandler<CreateCarCommand, bool>
{
    private readonly IGenericRepository<Car> _repository = repository;
    private readonly IValidator<Car> _validator = validator;

    public async Task<bool> Handle(CreateCarCommand request, CancellationToken ct)
    {
        var validationResult = await _validator.ValidateAsync(request.Car, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        return _repository.Create(request.Car);
    }
}
