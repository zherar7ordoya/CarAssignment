using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;
using Integrador.Presentation.Validators;

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

    public bool SavePerson(PersonDTO person)
    {
        ValidationHelper.Validate(person);
        if (person.Id == 0) return personService.CreatePerson(person);
        else return personService.UpdatePerson(person);
    }

    public bool DeletePerson(int personId)
    {
        return personService.DeletePerson(personId);
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

    public bool SaveCar(CarDTO car)
    {
        ValidationHelper.Validate(car);
        if (car.Id == 0) return carService.CreateCar(car);
        else return carService.UpdateCar(car);
    }

    public bool DeleteCar(int carId)
    {
        return carService.DeleteCar(carId);
    }

    // --- ASIGNACIONES ---
    public bool AssignCar(int personId, int carId)
    {
        return assignmentService.AssignCar(carId, personId);
    }

    public bool RemoveCar(int personId, int carId)
    {
        return assignmentService.RemoveCar(carId, personId);
    }
}
