using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Assignments;

public record AssignCarCommand(Person Person, Car Car) : IRequest<bool>;