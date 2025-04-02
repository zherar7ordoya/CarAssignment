using MediatR;

namespace Integrador.Application.Commands;

public record DeleteCarCommand(int CarId) : IRequest<Unit>;
