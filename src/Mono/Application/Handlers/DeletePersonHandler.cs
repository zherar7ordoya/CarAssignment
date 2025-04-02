using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class DeletePersonHandler(IGenericRepository<Person> repository)
           : IRequestHandler<DeletePersonCommand, Unit>
{
    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken ct)
    {
        var person = await repository.GetByIdAsync(request.PersonId, ct) ?? throw new ApplicationException("La persona no existe.");

        if (person.HasCars())
        {
            throw new ApplicationException("No se puede eliminar una persona que tiene autos asociados");
        }

        await repository.DeleteAsync(person, ct);

        return Unit.Value;
    }
}
