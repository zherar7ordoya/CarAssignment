using Integrador.Application.Interfaces.Exceptions;

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Integrador.Presentation.Helpers;

public static class ValidationHelper
{
    private static IExceptionHandler? _exceptionHandler;

    public static void Initialize(IExceptionHandler exceptionHandler)
    {
        _exceptionHandler = exceptionHandler;
    }

    public static void Validate<T>(T obj)
    {
        if (obj == null)
        {
            _exceptionHandler?.Handle(new ArgumentNullException(nameof(obj)), $"Error en {MethodBase.GetCurrentMethod()?.Name}");
            return; // Add return to prevent further execution
        }

        var context = new ValidationContext(obj);
        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(obj, context, results, true);

        if (!isValid)
        {
            var errors = string.Join(", ", results.Select(e => e.ErrorMessage));
            _exceptionHandler?.Handle(new ValidationException(errors), $"Error en {MethodBase.GetCurrentMethod()?.Name}");
        }
    }
}
