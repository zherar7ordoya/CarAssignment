using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.DTOs;

namespace Integrador.Application.Commands;

public record AssignCarCommand(int CarId, int PersonId) : IRequest<Unit>;
