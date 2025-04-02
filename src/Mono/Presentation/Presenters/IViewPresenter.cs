using Integrador.Application.DTOs;

namespace Integrador.Presentation.Presenters
{
    public interface IViewPresenter
    {
        Task AssignCar(int personId, int carId);
        Task DeleteCar(int carId);
        Task DeletePerson(int personId);
        Task<List<AssignedCarDTO>> ReadAssignedCars();
        Task<List<CarDTO>> ReadAvailableCars();
        Task<List<PersonDTO>> ReadPersons();
        Task RemoveCar(int personId, int carId);
        Task SaveCar(CarDTO carDto);
        Task SavePerson(PersonDTO personDto);
    }
}