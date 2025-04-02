using MediatR;
using Integrador.Application.DTOs;

namespace Integrador.Application.Queries;

public record ReadAssignedCarsQuery() : IRequest<List<AssignedCarDTO>>;
