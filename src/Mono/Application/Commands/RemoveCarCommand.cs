using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record RemoveCarCommand(Person Person, Car Car) : IRequest<Unit>;
