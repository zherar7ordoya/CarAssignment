using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class RemoveCarHandler
(
    IGenericRepository<Car> carRepository,
    IGenericRepository<Person> personRepository
) : IRequestHandler<RemoveCarCommand, Unit>
{
    public async Task<Unit> Handle(RemoveCarCommand request, CancellationToken ct)
    {
        // 1. Validar existencia
        var existingCar = await carRepository.GetByIdAsync(request.Car.Id, ct);
        var existingPerson = await personRepository.GetByIdAsync(request.Person.Id, ct);

        if (existingCar == null || existingPerson == null)
        {
            throw new DomainException("Auto o persona no existen.");
        }

        // 2. Validar relación
        if (!existingPerson.OwnsCar(existingCar))
        {
            throw new DomainException("El auto no pertenece a la persona.");
        }

        // 3. Remover relación bidireccional
        existingPerson.RemoveCar(existingCar);
        existingCar.RemoveOwner();

        // 4. Persistencia
        await carRepository.UpdateAsync(existingCar, ct);
        await personRepository.UpdateAsync(existingPerson, ct);

        return Unit.Value;
    }
}