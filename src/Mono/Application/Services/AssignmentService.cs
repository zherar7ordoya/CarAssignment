using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services
{
    public class AssignmentService
    (
        IGenericRepository<Car> carRepository,
        IGenericRepository<Person> personRepository,
        IExceptionHandler exceptionHandler
    ) : IAssignmentService
    {
        public bool AssignCar(int carId, int personId)
        {
            var car = carRepository.GetById(carId);
            var person = personRepository.GetById(personId);

            if (car == null || person == null)
            {
                exceptionHandler.Handle("Auto o persona no existen.");
                return false;
            }

            if (car.HasOwner())
            {
                exceptionHandler.Handle("El auto ya tiene un dueño.");
                return false;
            }

            car.DueñoId = person.Id;
            person.Autos.Add(car);

            return carRepository.Update(car) && personRepository.Update(person);
        }

        public bool RemoveCar(int carId, int personId)
        {
            var car = carRepository.GetById(carId);
            var person = personRepository.GetById(personId);

            if (car == null || person == null)
            {
                exceptionHandler.Handle("Auto o persona no existen.");
                return false;
            }

            if (!person.OwnsCar(car))
            {
                exceptionHandler.Handle("La persona no es dueña del auto.");
                return false;
            }

            person.RemoveCar(car);
            car.RemoveOwner();

            return carRepository.Update(car) && personRepository.Update(person);
        }
    }
}
