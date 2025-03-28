using Integrador.Domain.Entities;
using Integrador.Shared.Validators;
using System.Text.RegularExpressions;

namespace Integrador.Application.Validators;

public partial class CarValidator : IValidator<Car>
{
    [GeneratedRegex(@"^[A-Z]{2}\d{3}[A-Z]{2}$|^[A-Z]{3}\d{3}$")]
    private static partial Regex PatenteRegex();

    public ValidationResult Validate(Car car)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(car.Patente) || !PatenteRegex().IsMatch(car.Patente))
        {
            errors.Add("Patente - formato esperado: AA123AA o AAA123.");
        }

        if (string.IsNullOrEmpty(car.Marca))
        {
            errors.Add("La marca no puede estar vacía.");
        }

        if (string.IsNullOrEmpty(car.Modelo))
        {
            errors.Add("El modelo no puede estar vacío.");
        }

        if (car.Año < 1900 || car.Año > DateTime.Now.Year)
        {
            errors.Add("Año inválido.");
        }

        if (car.Precio <= 0)
        {
            errors.Add("El precio debe ser mayor a 0.");
        }

        return new ValidationResult(errors);
    }
}
