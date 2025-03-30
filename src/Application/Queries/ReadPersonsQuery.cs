using Integrador.Domain.Entities;

using MediatR;

namespace Integrador.Application.Queries;

public record ReadPersonsQuery : IRequest<List<Person>>;