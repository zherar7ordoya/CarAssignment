using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Presentation.Presenters.Helpers;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter
(
    IAssignmentService assignmentService,
    ICarService carService,
    IPersonService personService
) : IViewPresenter
{
    // --- PERSONAS ---
    public List<PersonDTO> ReadPersons()
    {
        return personService.GetPersons();
    }

    public void SavePerson(PersonDTO person)
    {
        ValidationHelper.Validate(person);
        if (person.Id == 0) personService.CreatePerson(person);
        else personService.UpdatePerson(person);
    }

    public void DeletePerson(int personId)
    {
        personService.DeletePerson(personId);
    }

    // --- AUTOS ---
    public List<CarDTO> ReadAvailableCars()
    {
        return carService.GetAvailableCars();
    }

    public List<AssignedCarDTO> ReadAssignedCars()
    {
        return personService.GetAssignedCars();
    }

    public void SaveCar(CarDTO car)
    {
        ValidationHelper.Validate(car);
        if (car.Id == 0) carService.CreateCar(car);
        else carService.UpdateCar(car);
    }

    public void DeleteCar(int carId)
    {
        carService.DeleteCar(carId);
    }

    // --- ASIGNACIONES ---
    public void AssignCar(int personId, int carId)
    {
        assignmentService.AssignCar(carId, personId);
    }

    public void RemoveCar(int personId, int carId)
    {
        assignmentService.RemoveCar(carId, personId);
    }
}
