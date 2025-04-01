using MediatR;
using Integrador.Domain.Entities;

namespace Integrador.Application.Commands;

public record DeleteCarCommand(int CarId) : IRequest<Unit>;
