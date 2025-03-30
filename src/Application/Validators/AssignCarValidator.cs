using FluentValidation;

using Integrador.Application.Commands;

namespace Integrador.Application.Validators;

public class AssignCarValidator : AbstractValidator<AssignCarCommand>
{
    public AssignCarValidator()
    {
        RuleFor(cmd => cmd.Car)
            .NotNull()
            .WithMessage("Auto no puede ser nulo.");

        RuleFor(cmd => cmd.Person)
            .NotNull()
            .WithMessage("Persona no puede ser nula.");
    }
}
