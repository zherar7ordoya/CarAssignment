using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record DeleteCarCommand(Car Car) : IRequest<Unit>;
