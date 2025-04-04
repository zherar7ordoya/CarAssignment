using Integrador.Application.DTOs;

namespace Integrador.Presentation.Presenters
{
    public interface IViewPresenter
    {
        bool AssignCar(int personId, int carId);
        bool DeleteCar(int carId);
        bool DeletePerson(int personId);
        List<AssignedCarDTO> ReadAssignedCars();
        List<CarDTO> ReadAvailableCars();
        List<PersonDTO> ReadPersons();
        bool RemoveCar(int personId, int carId);
        bool SaveCar(CarDTO carDto);
        bool SavePerson(PersonDTO personDto);
    }
}