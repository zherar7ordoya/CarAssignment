using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;

namespace Integrador.Shared.Exceptions;

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger _logger;
    private readonly IMessageBus _messageBus;

    // Inyección de dependencias
    public ExceptionHandler(ILogger logger, IMessageBus messageBus)
    {
        _logger = logger;
        _messageBus = messageBus;
    }

    public void Handle(Exception ex, string message)
    {
        _logger.LogError(message, ex);
        _messageBus.PublishError(message);
    }
}