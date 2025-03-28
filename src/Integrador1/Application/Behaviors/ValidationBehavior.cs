using System.Collections.Generic;
using FluentValidation;
using MediatR;
using Integrador.Domain.Exceptions;

namespace Integrador.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errors = failures
            .Where(f => f.Errors.Count > 0)
            .SelectMany(f => f.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        if (errors.Count > 0)
            throw new DomainException(errors);

        return await next();
    }
}
