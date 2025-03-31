using Integrador.Domain.Entities;

using MediatR;

namespace Integrador.Application.Queries;

public record ReadAvailableCarsQuery : IRequest<List<Car>>;