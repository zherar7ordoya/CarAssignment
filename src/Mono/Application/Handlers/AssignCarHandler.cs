using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;

namespace Integrador.Application.Handlers;

public class AssignCarHandler
(
    IGenericRepository<Car> carRepository,
    IGenericRepository<Person> personRepository
) : IRequestHandler<AssignCarCommand, Unit>
{
    public async Task<Unit> Handle(AssignCarCommand request, CancellationToken ct)
    {
        var existingCar = await carRepository.GetByIdAsync(request.Car.Id, ct);
        var existingPerson = await personRepository.GetByIdAsync(request.Person.Id, ct);

        if (existingCar == null || existingPerson == null)
        {
            throw new DomainException("Auto o persona no existen.");
        }

        if (existingCar.HasOwner())
        {
            throw new DomainException("El auto ya tiene un dueño.");
        }

        existingCar.AssignOwner(existingPerson.Id);
        existingPerson.AssignCar(existingCar);

        await carRepository.UpdateAsync(existingCar, ct);
        await personRepository.UpdateAsync(existingPerson, ct);

        return Unit.Value;
    }
}
