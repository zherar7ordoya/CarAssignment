using MediatR;
using Integrador.Application.Commands;
using Integrador.Application.Queries;
using Integrador.Application.Assignments;
using Integrador.Domain.Entities;
using Integrador.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Integrador.Shared.Exceptions;
using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Messaging;
using Integrador.Infrastructure.Logging;

namespace Integrador.Presentation.Presenters;

public class ViewPresenter(IMediator mediator)
{
    private readonly IMediator _mediator = mediator;
    readonly ILogger _logger = new Logger();
    readonly IMessenger _messenger = new Messenger();

    // --- PERSONAS ---
    public async Task<List<Person>> ListarPersonas()
    {
        try
        {
            return await _mediator.Send(new ReadPersonsQuery());
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al listar personas.");
            return [];
        }
    }

    public async Task NuevoPersona(BindingSource personasBS, Button button)
    {
        try
        {
            var nuevaPersona = new Person("12345678", "Nombre", "Apellido"); // Datos por defecto
            personasBS.Add(nuevaPersona);
            personasBS.MoveLast();
            button.Enabled = false;
        }
        catch (Exception ex)
        {
            await Task.Run(() => new ExceptionHandler(_logger, _messenger).Handle(ex));
        }
    }

    public async Task GuardarPersona(Person persona,
                                    BindingSource personasBS,
                                    Button nuevoPersonaButton)
    {
        try
        {
            // Crear o actualizar
            await _mediator.Send(persona.Id == 0
                ? new CreatePersonCommand(persona)
                : new UpdatePersonCommand(persona));

            // Actualizar UI
            personasBS.ResetBindings(false);
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al guardar persona.");
        }
        finally
        {
            nuevoPersonaButton.Enabled = true;
        }
    }

    public async Task EliminarPersona(Person persona, BindingSource personasBS)
    {
        try
        {
            await _mediator.Send(new DeletePersonCommand(persona));
            if (personasBS.DataSource is List<Person> lista)
            {
                lista.Remove(persona);
                personasBS.ResetBindings(false);
            }
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al eliminar persona.");
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
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al listar autos.");
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
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al listar autos asignados.");
            return [];
        }
    }

    public async Task NuevoAuto(BindingSource autosBS, Button button)
    {
        try
        {
            var nuevoAuto = new Car("AAA123", "Marca", "Modelo", 2023, 50000);
            autosBS.Add(nuevoAuto);
            autosBS.MoveLast();
            button.Enabled = false;
        }
        catch (Exception ex)
        {
            await Task.Run(() => new ExceptionHandler(_logger, _messenger).Handle(ex));
        }
    }

    public async Task GuardarAuto(Car auto,
                                 BindingSource autosBS,
                                 Button nuevoAutoButton)
    {
        try
        {
            await _mediator.Send(auto.Id == 0
                ? new CreateCarCommand(auto)
                : new UpdateCarCommand(auto));

            autosBS.ResetBindings(false);
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al guardar auto.");
        }
        finally
        {
            nuevoAutoButton.Enabled = true;
        }
    }

    public async Task EliminarAuto(Car auto, BindingSource autosBS)
    {
        try
        {
            await _mediator.Send(new DeleteCarCommand(auto));
            if (autosBS.DataSource is List<Car> lista)
            {
                lista.Remove(auto);
                autosBS.ResetBindings(false);
            }
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al eliminar auto.");
        }
    }

    // --- ASIGNACIONES ---
    public async Task AsignarAuto(Person persona, Car auto, Action onSuccess)
    {
        try
        {
            await _mediator.Send(new AssignCarCommand(persona, auto));
            onSuccess?.Invoke();
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al asignar auto.");
        }
    }

    public async Task DesasignarAuto(Person persona, Car auto, Action onSuccess)
    {
        try
        {
            await _mediator.Send(new RemoveCarCommand(persona, auto));
            onSuccess?.Invoke();
        }
        catch (DomainException ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al desasignar auto.");
        }
    }
}
