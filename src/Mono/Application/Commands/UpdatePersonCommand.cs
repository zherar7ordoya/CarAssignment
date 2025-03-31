using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record UpdatePersonCommand(Person Person) : IRequest<Unit>;