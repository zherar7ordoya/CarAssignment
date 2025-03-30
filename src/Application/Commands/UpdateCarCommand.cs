using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record UpdateCarCommand(Car Car) : IRequest<bool>;