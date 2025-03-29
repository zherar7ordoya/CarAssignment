using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Shared.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Integrador.Application.Assignments;
using Integrador.Domain.Exceptions;

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
        if (!existingPerson.EnsureCarCanBeRemoved(existingCar))
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