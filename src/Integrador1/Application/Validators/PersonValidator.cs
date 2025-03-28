using FluentValidation;
using Integrador.Domain.Entities;

namespace Integrador.Application.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El nombre es requerido.")
            .MaximumLength(100).WithMessage("Máximo 100 caracteres.");

        RuleFor(p => p.DNI)
            .NotEmpty().WithMessage("El documento es requerido.")
            .Matches(@"^\d{8}$").WithMessage("Formato inválido (ej: 12345678).");

        //RuleFor(p => p.Edad)
        //    .InclusiveBetween(18, 120).WithMessage("Edad debe ser entre 18 y 120.");
    }
}
