using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class AssignCarHandler
(
    IGenericRepository<Car> carRepository,
    IGenericRepository<Person> personRepository
) : IRequestHandler<AssignCarCommand, bool>
{
    private readonly IGenericRepository<Car> _carRepository = carRepository;
    private readonly IGenericRepository<Person> _personRepository = personRepository;

    public async Task<bool> Handle(AssignCarCommand request, CancellationToken ct)
    {
        var existingCar = await _carRepository.GetByIdAsync(request.Car.Id, ct);
        var existingPerson = await _personRepository.GetByIdAsync(request.Person.Id, ct);

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

        var carUpdateResult = await _carRepository.UpdateAsync(existingCar, ct);
        var personUpdateResult = await _personRepository.UpdateAsync(existingPerson, ct);

        return carUpdateResult && personUpdateResult;
    }
}
