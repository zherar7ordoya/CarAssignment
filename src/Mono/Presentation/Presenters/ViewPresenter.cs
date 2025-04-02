using Integrador.Application.DTOs;
using Integrador.Application.Validators;
using Integrador.Application.Interfaces;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter
(
    IAssignmentManager assignmentManager,
    ICarManager carManager,
    IPersonManager personManager
) : IViewPresenter
{
    // --- PERSONAS ---
    public async Task<List<PersonDTO>> ReadPersons()
    {
        return await personManager.GetPersons(CancellationToken.None);
    }

    public async Task SavePerson(PersonDTO person)
    {
        ValidationHelper.Validate(person);
        if (person.Id == 0) await personManager.CreatePerson(person, CancellationToken.None);
        else await personManager.UpdatePerson(person, CancellationToken.None);
    }

    public async Task DeletePerson(int personId)
    {
        await personManager.DeletePerson(personId, CancellationToken.None);
    }

    // --- AUTOS ---
    public async Task<List<CarDTO>> ReadAvailableCars()
    {
        return await carManager.GetAvailableCars(CancellationToken.None);
    }

    public async Task<List<AssignedCarDTO>> ReadAssignedCars()
    {
        return await personManager.GetAssignedCars(CancellationToken.None);
    }

    public async Task SaveCar(CarDTO car)
    {
        ValidationHelper.Validate(car);
        if (car.Id == 0) await carManager.CreateCar(car, CancellationToken.None);
        else await carManager.UpdateCar(car, CancellationToken.None);
    }

    public async Task DeleteCar(int carId)
    {
        await carManager.DeleteCar(carId, CancellationToken.None);
    }

    // --- ASIGNACIONES ---
    public async Task AssignCar(int personId, int carId)
    {
        await assignmentManager.AssignCar(carId, personId, CancellationToken.None);
    }

    public async Task RemoveCar(int personId, int carId)
    {
        await assignmentManager.RemoveCar(carId, personId, CancellationToken.None);
    }
}
