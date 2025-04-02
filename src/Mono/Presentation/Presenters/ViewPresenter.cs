using MediatR;
using Integrador.Application.Commands;
using Integrador.Application.Queries;
using Integrador.Application.DTOs;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter(IMediator mediator)
{
    // --- PERSONAS ---
    public async Task<List<PersonDTO>> ReadPersons()
    {
        return await mediator.Send(new ReadPersonsQuery());
    }

    public async Task SavePerson(PersonDTO person)
    {
        //var dto = new PersonDTO(person.Id,
        //                        person.DNI,
        //                        person.Nombre,
        //                        person.Apellido,
        //                        [.. person.Autos.Select(auto =>
        //                        new CarDTO(auto.Id,
        //                                   auto.Patente,
        //                                   auto.Marca,
        //                                   auto.Modelo,
        //                                   auto.Año,
        //                                   auto.Precio,
        //                                   auto.DueñoId))]);

        if (person.Id == 0) await mediator.Send(new CreatePersonCommand(person));
        else await mediator.Send(new UpdatePersonCommand(person));
    }

    public async Task DeletePerson(int personId)
    {
        await mediator.Send(new DeletePersonCommand(personId));
    }

    // --- AUTOS ---
    public async Task<List<CarDTO>> ReadAvailableCars()
    {
        return await mediator.Send(new ReadAvailableCarsQuery());
    }

    public async Task<List<AssignedCarDTO>> ReadAssignedCars()
    {
        return await mediator.Send(new ReadAssignedCarsQuery());
    }

    public async Task SaveCar(CarDTO car)
    {
        //var dto = new CarDTO(car.Id,
        //                     car.Patente,
        //                     car.Marca,
        //                     car.Modelo,
        //                     car.Año,
        //                     car.Precio,
        //                     car.DueñoId);

        if (car.Id == 0) await mediator.Send(new CreateCarCommand(car));
        else await mediator.Send(new UpdateCarCommand(car));
    }

    public async Task DeleteCar(int carId)
    {
        await mediator.Send(new DeleteCarCommand(carId));
    }

    // --- ASIGNACIONES ---
    public async Task AssignCar(int personId, int carId)
    {
        await mediator.Send(new AssignCarCommand(carId, personId));
    }

    public async Task RemoveCar(int personId, int carId)
    {
        await mediator.Send(new RemoveCarCommand(personId, carId));
    }
}
