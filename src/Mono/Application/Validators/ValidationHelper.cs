using System.ComponentModel.DataAnnotations;

namespace Integrador.Application.Validators;

public static class ValidationHelper
{
    public static void Validate<T>(T obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        var context = new ValidationContext(obj);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, context, results, true);

        if (!isValid)
        {
            var errors = string.Join(", ", results.Select(e => e.ErrorMessage));
            throw new ApplicationException(errors);
        }
    }
}
