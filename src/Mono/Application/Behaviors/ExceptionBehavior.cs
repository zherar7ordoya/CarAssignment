using Integrador.Domain.Exceptions;

using MediatR;

using System.Net;

namespace Integrador.Application.Behaviors;

public class ExceptionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request,
                                        RequestHandlerDelegate<TResponse> next,
                                        CancellationToken ct)
    {
        try
        {
            return await next();
        }
        catch (DomainException ex)
        {
            // Mapear a un resultado de error
            return ExceptionBehavior<TRequest, TResponse>.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception)
        {
            // Loguear excepción inesperada
            return ExceptionBehavior<TRequest, TResponse>.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error interno");
        }
    }

    private static TResponse CreateErrorResponse(HttpStatusCode statusCode, string message)
    {
        var response = Activator.CreateInstance(typeof(TResponse), statusCode, message);
        return response == null ? throw new InvalidOperationException("Unable to create error response") : (TResponse)response;
    }
}
