using Integrador.Shared.Validators;

namespace Integrador.Application.Validators;

public interface IValidator<in T>
{
    ValidationResult Validate(T entity);
}
