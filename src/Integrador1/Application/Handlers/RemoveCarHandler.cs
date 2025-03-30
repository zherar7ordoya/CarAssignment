using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class RemoveCarHandler(
    IGenericRepository<Car> carRepository,
    IGenericRepository<Person> personRepository)
    : IRequestHandler<RemoveCarCommand, bool>
{
    private readonly IGenericRepository<Car> _carRepository = carRepository;
    private readonly IGenericRepository<Person> _personRepository = personRepository;

    public async Task<bool> Handle(RemoveCarCommand request, CancellationToken ct)
    {
        // 1. Validar existencia
        var existingCar = _carRepository.GetById(request.Car.Id);
        var existingPerson = _personRepository.GetById(request.Person.Id);

        if (existingCar == null || existingPerson == null)
        {
            throw new DomainException("Auto o persona no existen.");
        }

        // 2. Validar relación
        if (existingPerson.OwnsCar(existingCar))
        {
            throw new DomainException("El auto no pertenece a la persona.");
        }

        // 3. Remover relación bidireccional
        existingPerson.RemoveCar(existingCar);
        existingCar.RemoveOwner();

        // 4. Persistencia
        bool carUpdated = await Task.Run(() => _carRepository.Update(existingCar));
        bool personUpdated = await Task.Run(() => _personRepository.Update(existingPerson));

        return carUpdated && personUpdated;
    }
}