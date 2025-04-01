using Integrador.Domain.Exceptions;
using Integrador.Shared.Interfaces;

using Serilog;

namespace Integrador.Shared.Exceptions;

public class ExceptionHandler(IMessenger messenger) : IExceptionHandler
{
    private readonly ILogger _logger = Log.ForContext<ExceptionHandler>();

    public void Handle(Exception ex) => Handle(ex, "Ocurrió un error inesperado.");

    public void Handle(Exception ex, string defaultMessage)
    {
        // Loguea con contexto estructurado
        _logger.Error(ex, "Error capturado: {Message}", defaultMessage);

        // Muestra mensaje al usuario según tipo de excepción
        switch (ex)
        {
            case DomainException domainEx:
                var errors = string.Join("\n- ", domainEx.Errors);
                messenger.ShowError(ex, $"Errores de negocio:\n- {errors}");
                break;
            default:
                messenger.ShowError(ex, $"{defaultMessage}\nConsulte el log para más detalles.");
                break;
        }
    }
}
