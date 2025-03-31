using Integrador.Infrastructure.Interfaces;

using Serilog;

namespace Integrador.Infrastructure.Exceptions;

public class ExceptionHandler(IMessenger messenger) : IExceptionHandler
{
    private readonly Serilog.ILogger _logger = Log.ForContext<ExceptionHandler>();

    public void Handle(Exception ex) => Handle(ex, string.Empty);

    public void Handle(Exception ex, string message)
    {
        _logger.Error(ex, message);
        messenger.ShowError(ex, message);
    }
}
