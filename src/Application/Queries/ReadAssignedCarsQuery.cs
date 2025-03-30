using MediatR;
using Integrador.Application.DTOs;

namespace Integrador.Application.Queries;

// Request inmutable
public record ReadAssignedCarsQuery() : IRequest<List<AssignedCarDTO>>;