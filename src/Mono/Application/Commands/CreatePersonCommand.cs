using MediatR;
using Integrador.Application.DTOs;

namespace Integrador.Application.Commands;

public record CreatePersonCommand(PersonDTO PersonDTO) : IRequest<Unit>;