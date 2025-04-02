using FluentValidation;

using Integrador.Application.Commands;

namespace Integrador.Application.Validators;

public class AssignCarValidator : AbstractValidator<AssignCarCommand>
{
    public AssignCarValidator()
    {
        RuleFor(cmd => cmd.CarId)
            .NotNull()
            .WithMessage("Auto no puede ser nulo.");

        RuleFor(cmd => cmd.PersonId)
            .NotNull()
            .WithMessage("Persona no puede ser nula.");
    }
}
