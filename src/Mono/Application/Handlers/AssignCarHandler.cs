using MediatR;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Application.Interfaces;
using Integrador.Application.DTOs;
using Integrador.Domain.Entities;

namespace Integrador.Application.Handlers;

public class AssignCarHandler
(
    IGenericRepository<Car> carRepository,
    IGenericRepository<Person> personRepository
) : IRequestHandler<AssignCarCommand, Unit>
{
    public async Task<Unit> Handle(AssignCarCommand request, CancellationToken ct)
    {
        var existingCar = await carRepository.GetByIdAsync(request.CarId, ct);
        var existingPerson = await personRepository.GetByIdAsync(request.PersonId, ct);

        if (existingCar == null || existingPerson == null)
        {
            throw new DomainException("Auto o persona no existen.");
        }

        if (existingCar.HasOwner())
        {
            throw new DomainException("El auto ya tiene un dueño.");
        }

        // Asignamos el dueño sin modificar directamente la entidad
        existingCar.DueñoId = existingPerson.Id;
        existingPerson.Autos.Add(existingCar);

        await carRepository.UpdateAsync(existingCar, ct);
        await personRepository.UpdateAsync(existingPerson, ct);

        return Unit.Value;
    }
}
