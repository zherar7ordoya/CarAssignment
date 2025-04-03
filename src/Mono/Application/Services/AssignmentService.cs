using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services
{
    public class AssignmentService
    (
        IGenericRepository<Car> carRepository,
        IGenericRepository<Person> personRepository,
        IExceptionHandler exceptionHandler
    ) : IAssignmentManager
    {
        public async Task AssignCar(int carId, int personId, CancellationToken ct)
        {
            var car = await carRepository.GetByIdAsync(carId, ct);
            var person = await personRepository.GetByIdAsync(personId, ct);

            if (car == null || person == null)
            {
                exceptionHandler.Handle("Auto o persona no existen.");
                return;
            }

            if (car.HasOwner())
            {
                exceptionHandler.Handle("El auto ya tiene un dueño.");
                return;
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
                exceptionHandler.Handle("Auto o persona no existen.");
                return;
            }

            if (!person.OwnsCar(car))
            {
                exceptionHandler.Handle("La persona no es dueña del auto.");
                return;
            }

            person.RemoveCar(car);
            car.RemoveOwner();

            await carRepository.UpdateAsync(car, ct);
            await personRepository.UpdateAsync(person, ct);
        }
    }
}
