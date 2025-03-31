using FluentValidation;

using Integrador.Domain.Entities;

namespace Integrador.Application.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.DNI)
            .NotEmpty().WithMessage("DNI es requerido.")
            .Matches(@"^\d{8}$").WithMessage("Formato inválido (ej: 12345678).");

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("Nombre es requerido.")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres.");

        RuleFor(p => p.Apellido)
            .NotEmpty().WithMessage("Apellido es requerido.")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres.");
    }
}
