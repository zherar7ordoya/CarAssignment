using MediatR;
using Integrador.Application.DTOs;

namespace Integrador.Application.Commands;

public record UpdatePersonCommand(PersonDTO PersonDTO) : IRequest<Unit>;