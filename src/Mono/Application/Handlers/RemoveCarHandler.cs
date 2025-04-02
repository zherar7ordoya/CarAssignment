using MediatR;
using Integrador.Domain.Entities;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

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
        var existingCar = await carRepository.GetByIdAsync(request.CarId, ct);
        var existingPerson = await personRepository.GetByIdAsync(request.PersonId, ct);

        if (existingCar == null || existingPerson == null)
        {
            throw new Exception("Auto o persona no existen.");
        }

        // 2. Validar relación
        if (!existingPerson.OwnsCar(existingCar))
        {
            throw new Exception("El auto no pertenece a la persona.");
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
