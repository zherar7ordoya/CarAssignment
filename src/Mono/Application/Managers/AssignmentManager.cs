using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Managers
{
    public class AssignmentManager
    (
        IGenericRepository<Car> carRepository,
        IGenericRepository<Person> personRepository
    ) : IAssignmentManager
    {
        public async Task AssignCar(int carId, int personId, CancellationToken ct)
        {
            var car = await carRepository.GetByIdAsync(carId, ct);
            var person = await personRepository.GetByIdAsync(personId, ct);

            if (car == null || person == null)
            {
                throw new Exception("Auto o persona no existen.");
            }

            if (car.HasOwner())
            {
                throw new Exception("El auto ya tiene un dueño.");
            }

            car.DueñoId = person.Id;
            person.Autos.Add(car);

            await carRepository.UpdateAsync(car, ct);
            await personRepository.UpdateAsync(person, ct);
        }

        public async Task RemoveCar(int carId, int personId, CancellationToken ct)
        {
            var car = await carRepository.GetByIdAsync(carId, ct);
            var person = await personRepository.GetByIdAsync(personId, ct);

            if (car == null || person == null)
            {
                throw new Exception("Auto o persona no existen.");
            }

            if (!person.OwnsCar(car))
            {
                throw new Exception("El auto no pertenece a la persona.");
            }

            person.RemoveCar(car);
            car.RemoveOwner();

            await carRepository.UpdateAsync(car, ct);
            await personRepository.UpdateAsync(person, ct);
        }
    }
}
