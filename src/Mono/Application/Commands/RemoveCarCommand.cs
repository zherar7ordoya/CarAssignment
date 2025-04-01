using MediatR;

namespace Integrador.Application.Commands;

public record RemoveCarCommand(int PersonId, int CarId) : IRequest<Unit>;
