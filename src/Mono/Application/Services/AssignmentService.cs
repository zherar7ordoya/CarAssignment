using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Application.Interfaces.Services;
using Integrador.Domain.Entities;

namespace Integrador.Application.Services
{
    public class AssignmentService
    (
        IRepository<Car> carRepository,
        IRepository<Person> personRepository,
        IMessenger messenger
    ) : IAssignmentService
    {
        public void AssignCar(int carId, int personId)
        {
            var car = carRepository.ReadById(carId);
            var person = personRepository.ReadById(personId);

            if (car == null || person == null)
            {
                messenger.ShowInformation("Car or person do not exist.");
                return;
            }

            if (car.HasOwner())
            {
                messenger.ShowInformation("Car already has an owner.");
                return;
            }

            car.DueñoId = person.Id;
            person.Autos.Add(carId);

            carRepository.Update(car);
            personRepository.Update(person);
        }

        public void RemoveCar(int carId, int personId)
        {
            var car = carRepository.ReadById(carId);
            var person = personRepository.ReadById(personId);

            if (car == null || person == null)
            {
                messenger.ShowInformation("Car or person do not exist.");
                return;
            }

            if (!person.OwnsCar(carId))
            {
                messenger.ShowInformation("Car does not belong to the person.");
                return;
            }

            person.RemoveCar(carId);
            car.RemoveOwner();

            carRepository.Update(car);
            personRepository.Update(person);
        }
    }
}
