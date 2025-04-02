using MediatR;

using Microsoft.Extensions.Logging;


namespace Integrador.Application.Behaviors;

public class ExceptionLoggingBehavior<TRequest, TResponse>(ILogger logger)
           : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            // Registra errores técnicos
            logger.LogError(ex, "Error técnico en: {RequestName}", typeof(TRequest).Name);
            throw new ApplicationException("Error interno", ex);
        }
    }
}
