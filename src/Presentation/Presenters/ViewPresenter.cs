using MediatR;
using Integrador.Application.Commands;
using Integrador.Application.Queries;
using Integrador.Domain.Entities;
using Integrador.Application.DTOs;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter(IMediator mediator)
{
    private readonly IMediator _mediator = mediator;

    // --- PERSONAS ---
    public async Task<List<Person>> ListarPersonas()
    {
        return await _mediator.Send(new ReadPersonsQuery());
    }

    public async Task<bool> GuardarPersona(Person persona)
    {
        if (persona.Id == 0)
        {
            return await _mediator.Send(new CreatePersonCommand(persona));
        }
        else
        {
            return await _mediator.Send(new UpdatePersonCommand(persona));
        }
    }

    public async Task<bool> EliminarPersona(Person persona)
    {
        return await _mediator.Send(new DeletePersonCommand(persona));
    }

    // --- AUTOS ---
    public async Task<List<Car>> ListarAutosDisponibles()
    {
        return await _mediator.Send(new ReadAvailableCarsQuery());
    }

    public async Task<List<AssignedCarDTO>> ListarAutosAsignados()
    {
        return await _mediator.Send(new ReadAssignedCarsQuery());
    }

    public async Task<bool> GuardarAuto(Car auto)
    {
        if (auto.Id == 0)
        {
            return await _mediator.Send(new CreateCarCommand(auto));
        }
        else
        {
            return await _mediator.Send(new UpdateCarCommand(auto));
        }
    }

    public async Task<bool> EliminarAuto(Car auto)
    {
        return await _mediator.Send(new DeleteCarCommand(auto));
    }

    // --- ASIGNACIONES ---
    public async Task<bool> AsignarAuto(Person persona, Car auto)
    {
        return await _mediator.Send(new AssignCarCommand(persona, auto));
    }

    public async Task<bool> DesasignarAuto(Person persona, Car auto)
    {
        return await _mediator.Send(new RemoveCarCommand(persona, auto));
    }
}
