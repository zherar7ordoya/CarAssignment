using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record AssignCarCommand(Person Person, Car Car) : IRequest<bool>;