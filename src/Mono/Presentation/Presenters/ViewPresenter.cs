using MediatR;
using Integrador.Application.Commands;
using Integrador.Application.Queries;
using Integrador.Domain.Entities;
using Integrador.Application.DTOs;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter(IMediator mediator)
{

    // --- PERSONAS ---
    public async Task<List<Person>> ListarPersonas()
    {
        return await mediator.Send(new ReadPersonsQuery());
    }

    public void GuardarPersona(Person persona)
    {
        if (persona.Id == 0) mediator.Send(new CreatePersonCommand(persona));
        else mediator.Send(new UpdatePersonCommand(persona));
    }

    public void EliminarPersona(Person persona) => mediator.Send(new DeletePersonCommand(persona));

    // --- AUTOS ---
    public async Task<List<Car>> ListarAutosDisponibles()
    {
        return await mediator.Send(new ReadAvailableCarsQuery());
    }

    public async Task<List<AssignedCarDTO>> ListarAutosAsignados()
    {
        return await mediator.Send(new ReadAssignedCarsQuery());
    }

    public void GuardarAuto(Car auto)
    {
        if (auto.Id == 0) mediator.Send(new CreateCarCommand(auto));
        else mediator.Send(new UpdateCarCommand(auto));
    }

    public void EliminarAuto(Car auto) => mediator.Send(new DeleteCarCommand(auto));

    // --- ASIGNACIONES ---
    public void AsignarAuto(Person persona, Car auto) => mediator.Send(new AssignCarCommand(persona, auto));

    public void DesasignarAuto(Person persona, Car auto) => mediator.Send(new RemoveCarCommand(persona, auto));
}
