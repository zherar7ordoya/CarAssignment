using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.DTOs;

namespace Integrador.Application.Commands;

public record UpdateCarCommand(CarDTO CarDTO) : IRequest<Unit>;