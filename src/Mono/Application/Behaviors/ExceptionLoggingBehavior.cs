using MediatR;
using Serilog;
using Integrador.Domain.Exceptions;

using ApplicationException = Integrador.Application.Exceptions.ApplicationException;

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
        catch (DomainException dex)
        {
            // Convierte DomainException en ApplicationException
            logger.Warning(dex, "Error de dominio: {Message}", dex.Message);
            throw new ApplicationException(dex.Message, dex);
        }
        catch (Exception ex)
        {
            // Registra errores técnicos
            logger.Error(ex, "Error técnico en: {RequestName}", typeof(TRequest).Name);
            throw new ApplicationException("Error interno", ex);
        }
    }
}
