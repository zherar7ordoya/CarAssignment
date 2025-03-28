using FluentValidation;

using Integrador.Domain.Entities;

namespace Integrador.Application.Validators;

public partial class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(c => c.Patente)
            .NotEmpty()
            .Matches(@"^[A-Z]{2}\d{3}[A-Z]{2}$|^[A-Z]{3}\d{3}$")
            .WithMessage("Formato de patente inválido (ej: ABC123 o ABC123DEF).");

        RuleFor(c => c.Marca).NotEmpty().WithMessage("La marca es requerida.");
        RuleFor(c => c.Modelo).NotEmpty().WithMessage("El modelo es requerido.");
        RuleFor(c => c.Año).InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Año inválido.");
        RuleFor(c => c.Precio).GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");
    }
}
