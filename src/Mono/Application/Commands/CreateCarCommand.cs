using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record CreateCarCommand(Car Car) : IRequest<Unit>;