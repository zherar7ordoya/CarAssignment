using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Exceptions;
using Integrador.Application.Commands;
using Integrador.Domain.Interfaces;

namespace Integrador.Application.Handlers;

public class AssignCarHandler(
    IGenericRepository<Car> carRepository,
    IGenericRepository<Person> personRepository)
    : IRequestHandler<AssignCarCommand, bool>
{
    private readonly IGenericRepository<Car> _carRepository = carRepository;
    private readonly IGenericRepository<Person> _personRepository = personRepository;

    public async Task<bool> Handle(AssignCarCommand request, CancellationToken ct)
    {
        // Validar existencia
        var existingCar = await Task.Run(() => _carRepository.GetById(request.Car.Id));
        var existingPerson = await Task.Run(() => _personRepository.GetById(request.Person.Id));

        if (existingCar == null || existingPerson == null)
        {
            throw new DomainException("Auto o persona no existen.");
        }

        // Validar regla de negocio
        if (existingCar.HasOwner())
        {
            throw new DomainException("El auto ya tiene un dueño.");
        }

        // Actualizar relaciones mediante IDs
        existingCar.AssignOwner(existingPerson);
        existingPerson.AssignCar(existingCar);

        // Persistir cambios
        return _carRepository.Update(existingCar) &&
               _personRepository.Update(existingPerson);
    }
}
