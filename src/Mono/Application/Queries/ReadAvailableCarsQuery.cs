using Integrador.Application.DTOs;

using MediatR;

namespace Integrador.Application.Queries;

public record ReadAvailableCarsQuery : IRequest<List<CarDTO>>;
