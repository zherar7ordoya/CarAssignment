using Integrador.Application.DTOs;

namespace Integrador.Application.Interfaces.Presentation
{
    public interface IViewPresenter
    {
        void AssignCar(int personId, int carId);
        void DeleteCar(int carId);
        void DeletePerson(int personId);
        List<AssignedCarDTO> ReadAssignedCars();
        List<CarDTO> ReadAvailableCars();
        List<PersonDTO> ReadPersons();
        void RemoveCar(int personId, int carId);
        void SaveCar(CarDTO carDto);
        void SavePerson(PersonDTO personDto);
    }
}