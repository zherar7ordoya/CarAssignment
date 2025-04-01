using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class DeletePersonHandler
(
    IGenericRepository<Person> repository
) : IRequestHandler<DeletePersonCommand, Unit>
{
    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken ct)
    {
        // 1. Obtener la persona por Id
        var person = await repository.GetByIdAsync(request.PersonId, ct) ?? throw new ApplicationException("La persona no existe.");

        // 2. Validación de Negocio: No permitir eliminar si hay autos asociados
        if (person.HasCars())
        {
            throw new ApplicationException("No se puede eliminar una persona que tiene autos asociados");
        }

        // 3. Eliminar la persona
        await repository.DeleteAsync(person, ct);

        return Unit.Value;
    }
}
