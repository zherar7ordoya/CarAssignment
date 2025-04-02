using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class CreatePersonHandler(IGenericRepository<Person> repository)
           : IRequestHandler<CreatePersonCommand, Unit>
{
    public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken ct)
    {
        var person = new Person
        (
            request.PersonDTO.Nombre,
            request.PersonDTO.Apellido,
            request.PersonDTO.DNI
        );

        await repository.CreateAsync(person, ct);

        return Unit.Value;
    }
}
