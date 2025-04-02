using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;

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
        Task SaveCar(ICar car);
        Task SavePerson(IPerson person);
    }
}