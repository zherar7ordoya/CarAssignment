using Integrador.Domain.Interfaces;

namespace Integrador.Shared.Exceptions;

public class ExceptionHandler(ILogger logger, IMessageBus messageBus) : IExceptionHandler
{
    private readonly ILogger _logger = logger;
    private readonly IMessageBus _messageBus = messageBus;

    public void Handle(Exception ex, string message)
    {
        _logger.LogError(message, ex);
        _messageBus.PublishError(message);
    }
}