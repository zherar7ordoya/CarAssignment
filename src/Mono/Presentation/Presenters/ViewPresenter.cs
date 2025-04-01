using MediatR;
using Integrador.Application.Commands;
using Integrador.Application.Queries;
using Integrador.Application.DTOs;
using Integrador.Application.Interfaces;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter(IMediator mediator)
{

    // --- PERSONAS ---
    public async Task<List<IPerson>> ReadPersons()
    {
        return await mediator.Send(new ReadPersonsQuery());
    }

    public void SavePerson(IPerson person)
    {
        if (person.Id == 0) mediator.Send(new CreatePersonCommand(person));
        else mediator.Send(new UpdatePersonCommand(person));
    }

    public void DeletePerson(IPerson person) => mediator.Send(new DeletePersonCommand(person));

    // --- AUTOS ---
    public async Task<List<ICar>> ReadAvailableCars()
    {
        return await mediator.Send(new ReadAvailableCarsQuery());
    }

    public async Task<List<AssignedCarDTO>> ReadAssignedCars()
    {
        return await mediator.Send(new ReadAssignedCarsQuery());
    }

    public void SaveCar(ICar car)
    {
        if (car.Id == 0) mediator.Send(new CreateCarCommand(car));
        else mediator.Send(new UpdateCarCommand(car));
    }

    public void DeleteCar(ICar car) => mediator.Send(new DeleteCarCommand(car));

    // --- ASIGNACIONES ---
    public void AssignCar(IPerson person, ICar car) => mediator.Send(new AssignCarCommand(person, car));

    public void RemoveCar(IPerson person, ICar car) => mediator.Send(new RemoveCarCommand(person, car));
}
