using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class UpdatePersonHandler(IGenericRepository<Person> repository)
           : IRequestHandler<UpdatePersonCommand, Unit>
{
    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken ct)
    {
        var personEntity = new Person
        (
            request.PersonDTO.Id,
            request.PersonDTO.DNI,
            request.PersonDTO.Nombre,
            request.PersonDTO.Apellido,
            [.. request.PersonDTO.Autos.Select(auto => new Car
            (
                auto.Patente,
                auto.Marca,
                auto.Modelo,
                auto.Año,
                auto.Precio
            ))]
        );

        var existingPerson = await repository.GetByIdAsync(request.PersonDTO.Id, ct) ?? throw new ApplicationException("La persona no existe.");
        await repository.UpdateAsync(personEntity, ct);

        return Unit.Value;
    }
}
