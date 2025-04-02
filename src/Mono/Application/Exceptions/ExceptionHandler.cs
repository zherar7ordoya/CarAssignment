using Integrador.Application.Interfaces;

using Microsoft.Extensions.Logging;

namespace Integrador.Application.Exceptions;

public class ExceptionHandler(IMessenger messenger, ILogger<ExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger = logger;

    public void Handle(Exception ex) => Handle(ex, "Ocurrió un error inesperado.");

    public void Handle(Exception ex, string defaultMessage)
    {
        // Loguea con contexto estructurado
        _logger.LogError(ex, "Error capturado: {Message}", defaultMessage);
        messenger.ShowError(ex, $"{defaultMessage}\nConsulte el log para más detalles.");
    }
}
