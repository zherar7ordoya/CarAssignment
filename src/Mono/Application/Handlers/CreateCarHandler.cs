using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Domain.Exceptions;
using FluentValidation;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class CreateCarHandler
(
    IGenericRepository<Car> repository,
    IValidator<Car> validator
) : IRequestHandler<CreateCarCommand, Unit>
{
    public async Task<Unit> Handle(CreateCarCommand request, CancellationToken ct)
    {
        var validationResult = await validator.ValidateAsync(request.Car, ct);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new DomainException(errors);
        }

        await repository.CreateAsync(request.Car, ct);

        return Unit.Value;
    }
}
