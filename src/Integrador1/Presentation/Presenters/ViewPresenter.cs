using Integrador.Application.Assignments;
using Integrador.Application.Commands;
using Integrador.Application.DTOs;
using Integrador.Application.Queries;
using Integrador.Domain.Entities;
using Integrador.Shared.Exceptions;

namespace Integrador.Presentation.Presenters;

public partial class ViewPresenter
{
    public static List<Person> ListarPersonas()
    {
        var (Success, Result, Error) = new ReadPersonsQuery().Execute();

        if (Success && Result != null)
        {
            return Result;
        }

        ExceptionHandler.HandleException
        (
            Error.Message ?? "Error al listar personas.",
            new Exception(Error.Message ?? "Error desconocido.")
        );

        return [];
    }

    public static void NuevoPersona(BindingSource personasBS, Button nuevoPersonaButton)
    {
        var nuevoPersona = new Person();
        var (Success, Error) = ExceptionHandler.Execute(() =>
        {
            personasBS.Add(nuevoPersona);
            personasBS.MoveLast();
        });

        if (Success)
        {
            nuevoPersonaButton.Enabled = false;
        }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al crear una nueva persona.",
                Error ?? new Exception("Error desconocido.")
            );
        }
    }

    public static void GuardarPersona(Person persona,
                                      BindingSource personasBS,
                                      Button nuevoPersonaButton)
    {
        ICommand command = persona.Id == 0
            ? new CreatePersonCommand(persona)
            : new UpdatePersonCommand(persona);

        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success)
        {
            personasBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al guardar la persona.",
                Error ?? new Exception("Error desconocido.")
            );
        }
        nuevoPersonaButton.Enabled = true;
    }

    public static void EliminarPersona(Person persona, BindingSource personasBS)
    {
        var command = new DeletePersonCommand(persona);
        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success && personasBS.DataSource is List<Person> lista)
        {
            lista.Remove(persona);
            personasBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al eliminar la persona.",
                Error ?? new Exception("Error desconocido.")
            );
        }
    }

    //..........................................................................

    public static List<Car> ListarAutosDisponibles()
    {
        var (Success, Result, Error) = new ReadAvailableCarsQuery().Execute();

        if (Success && Result != null)
        {
            return Result;
        }

        ExceptionHandler.HandleException
        (
            Error.Message ?? "Error al listar autos disponibles.",
            new Exception(Error.Message ?? "Error desconocido")
        );

        return [];
    }

    public static List<AssignedCarDTO> ListarAutosAsignados()
    {
        var (Success, Result, Error) = new ReadAssignedCarsQuery().Execute();

        if (Success && Result != null)
        {
            return Result;
        }

        ExceptionHandler.HandleException
        (
            Error.Message ?? "Error al listar autos asignados.",
            new Exception(Error.Message ?? "Error desconocido")
        );

        return [];
    }

    public static void NuevoAuto(BindingSource autosDisponiblesBS, Button nuevoAutoButton)
    {
        var nuevoAuto = new Car();
        var (Success, Error) = ExceptionHandler.Execute(() =>
        {
            autosDisponiblesBS.Add(nuevoAuto);
            autosDisponiblesBS.MoveLast();
        });

        if (Success)
        {
            nuevoAutoButton.Enabled = false;
        }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al crear una nueva persona.",
                Error ?? new Exception("Error desconocido.")
            );
        }
    }

    public static void GuardarAuto(Car auto,
                                   BindingSource autosDisponiblesBS,
                                   Button nuevoAutoButton)
    {
        ICommand command = auto.Id == 0
            ? new CreateCarCommand(auto)
            : new UpdateCarCommand(auto);

        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success)
        {
            autosDisponiblesBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al guardar auto.",
                Error ?? new Exception("Error desconocido.")
            );
        }
        nuevoAutoButton.Enabled = true;
    }

    public static void EliminarAuto(Car auto, BindingSource autosDisponiblesBS)
    {
        var command = new DeleteCarCommand(auto);
        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success && autosDisponiblesBS.DataSource is List<Car> lista)
        {
            lista.Remove(auto);
            autosDisponiblesBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al eliminar auto.",
                Error ?? new Exception("Error desconocido.")
            );
        }
    }

    //..........................................................................

    public static void AsignarAuto(Person persona,
                                   Car auto,
                                   Action<Person, Car> onSuccess)
    {
        var command = new AssignCarCommand(persona, auto);
        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success) { onSuccess?.Invoke(persona, auto); }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al asignar auto.",
                Error ?? new Exception("Error desconocido.")
            );
        }
    }

    public static void DesasignarAuto(Person persona,
                                      Car auto,
                                      Action<Person, Car> onSuccess)
    {
        var command = new RemoveCarCommand(persona, auto);
        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success) { onSuccess?.Invoke(persona, auto); }
        else
        {
            ExceptionHandler.HandleException
            (
                "Error al desasignar auto.",
                Error ?? new Exception("Error desconocido.")
            );
        }
    }
}
