using MediatR;
using Integrador.Application.Commands;
using Integrador.Application.Queries;
using Integrador.Domain.Entities;
using Integrador.Application.DTOs;
using Integrador.Domain.Exceptions;
using Integrador.Infrastructure.Exceptions;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter(IMediator mediator,
                           IExceptionHandler exceptionHandler)
{
    private readonly IMediator _mediator = mediator;
    private readonly IExceptionHandler _exceptionHandler = exceptionHandler;

    // --- PERSONAS ---
    public async Task<List<Person>> ListarPersonas()
    {
        try
        {
            return await _mediator.Send(new ReadPersonsQuery());
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al listar personas.");
            return [];
        }
    }

    public async Task<bool> GuardarPersona(Person persona)
    {
        try
        {
            await _mediator.Send(persona.Id == 0
                ? new CreatePersonCommand(persona)
                : new UpdatePersonCommand(persona));
            return true;
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar persona.");
            return false;
        }
    }

    public async Task<bool> EliminarPersona(Person persona)
    {
        try
        {
            await _mediator.Send(new DeletePersonCommand(persona));
            return true;
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar persona.");
            return false;
        }
    }

    // --- AUTOS ---
    public async Task<List<Car>> ListarAutosDisponibles()
    {
        try
        {
            return await _mediator.Send(new ReadAvailableCarsQuery());
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al listar autos.");
            return [];
        }
    }

    public async Task<List<AssignedCarDTO>> ListarAutosAsignados()
    {
        try
        {
            return await _mediator.Send(new ReadAssignedCarsQuery());
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al listar autos asignados.");
            return [];
        }
    }

    public async Task<bool> GuardarAuto(Car auto)
    {
        try
        {
            await _mediator.Send(auto.Id == 0
                ? new CreateCarCommand(auto)
                : new UpdateCarCommand(auto));
            return true;
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar auto.");
            return false;
        }
    }

    public async Task<bool> EliminarAuto(Car auto)
    {
        try
        {
            await _mediator.Send(new DeleteCarCommand(auto));
            return true;
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar auto.");
            return false;
        }
    }

    // --- ASIGNACIONES ---
    public async Task<bool> AsignarAuto(Person persona, Car auto)
    {
        try
        {
            await _mediator.Send(new AssignCarCommand(persona, auto));
            return true;
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al asignar auto.");
            return false;
        }
    }

    public async Task<bool> DesasignarAuto(Person persona, Car auto)
    {
        try
        {
            await _mediator.Send(new RemoveCarCommand(persona, auto));
            return true;
        }
        catch (DomainException ex)
        {
            _exceptionHandler.Handle(ex, "Error al desasignar auto.");
            return false;
        }
    }
}
