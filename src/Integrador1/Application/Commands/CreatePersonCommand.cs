using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record CreatePersonCommand(Person Person) : IRequest<bool>;