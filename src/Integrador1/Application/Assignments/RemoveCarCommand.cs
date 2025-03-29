using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Assignments;

public record RemoveCarCommand(Person Person, Car Car) : IRequest<bool>;
