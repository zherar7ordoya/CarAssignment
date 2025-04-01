using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record DeletePersonCommand(int PersonId) : IRequest<Unit>;