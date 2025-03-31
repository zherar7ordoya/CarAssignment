using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record DeletePersonCommand(Person Person) : IRequest<Unit>;