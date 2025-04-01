using MediatR;
using Integrador.Application.DTOs;

namespace Integrador.Application.Commands;

public record CreateCarCommand(CarDTO CarDTO) : IRequest<Unit>;
