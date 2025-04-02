using MediatR;

namespace Integrador.Application.Commands;

public record AssignCarCommand(int CarId, int PersonId) : IRequest<Unit>;
