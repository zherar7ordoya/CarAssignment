using Integrador.Application.Interfaces;

using MediatR;

namespace Integrador.Application.Queries;

public record ReadPersonsQuery : IRequest<List<IPerson>>;