using FluentValidation;

using Integrador.Application.Assignments;
using Integrador.Domain.Entities;

namespace Integrador.Application.Validators;

public class RemoveCarValidator : AbstractValidator<RemoveCarCommand>
{
    public RemoveCarValidator()
    {
        RuleFor(cmd => cmd.Car)
            .NotNull().WithMessage("Auto no puede ser nulo.");

        RuleFor(cmd => cmd.Person)
            .NotNull().WithMessage("Persona no puede ser nula.");
    }
}
