using MediatR;
using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Shared.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Integrador.Application.Assignments;

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
        // 1. Validación de negocio
        request.Car.EnsureCanBeAssigned(); // Verifica si el auto ya tiene dueño

        // 2. Asignación bidireccional
        request.Person.AssignCar(request.Car); // Encapsula lógica en dominio

        // 3. Persistencia
        bool carUpdated = await Task.Run(() => _carRepository.Update(request.Car));
        bool personUpdated = await Task.Run(() => _personRepository.Update(request.Person));

        return carUpdated && personUpdated;
    }
}
