using Integrador.Domain.Interfaces;

namespace Integrador.Shared.Exceptions;

public class ExceptionHandler(ILogger logger, IMessenger messenger) : IExceptionHandler
{
    private readonly ILogger _logger = logger;
    private readonly IMessenger _messenger = messenger;

    public void Handle(Exception ex) => Handle(ex, string.Empty);
    public void Handle(Exception ex, string message)
    {
        _logger.LogError(ex, message);
        _messenger.ShowError(ex, message);
    }
}