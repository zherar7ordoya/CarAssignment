using Integrador.Abstractions;
using Integrador.Adapters.Presentation.ViewModels;
using Integrador.Entities;
using Integrador.Infrastructure;
using Integrador.UseCases.Asignaciones;
using Integrador.UseCases.Autos;
using Integrador.UseCases.Personas;

namespace Integrador.Adapters.Presentation.Presenters;

public partial class ViewPresenter
{
    public static List<Persona> ListarPersonas()
    {
        var (Success, Result, Error) = new ReadPersonasQuery().Execute();

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
        var nuevoPersona = new Persona();
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

    public static void GuardarPersona(Persona persona,
                                      BindingSource personasBS,
                                      Button nuevoPersonaButton)
    {
        ICommand command = persona.Id == 0
            ? new CreatePersonaCommand(persona)
            : new UpdatePersonaCommand(persona);

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

    public static void EliminarPersona(Persona persona, BindingSource personasBS)
    {
        var command = new DeletePersonaCommand(persona);
        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success && personasBS.DataSource is List<Persona> lista)
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

    public static List<Auto> ListarAutosDisponibles()
    {
        var (Success, Result, Error) = new ReadAutosDisponiblesQuery().Execute();

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

    public static List<AssignedAutoViewModel> ListarAutosAsignados()
    {
        var (Success, Result, Error) = new ReadAutosAsignadosQuery().Execute();

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
        var nuevoAuto = new Auto();
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

    public static void GuardarAuto(Auto auto,
                                   BindingSource autosDisponiblesBS,
                                   Button nuevoAutoButton)
    {
        ICommand command = auto.Id == 0
            ? new CreateAutoCommand(auto)
            : new UpdateAutoCommand(auto);

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

    public static void EliminarAuto(Auto auto, BindingSource autosDisponiblesBS)
    {
        var command = new DeleteAutoCommand(auto);
        var (Success, Error) = ExceptionHandler.Execute(command.Execute);

        if (Success && autosDisponiblesBS.DataSource is List<Auto> lista)
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

    public static void AsignarAuto(Persona persona,
                                   Auto auto,
                                   Action<Persona, Auto> onSuccess)
    {
        var command = new AssociateAutoCommand(persona, auto);
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

    public static void DesasignarAuto(Persona persona,
                                      Auto auto,
                                      Action<Persona, Auto> onSuccess)
    {
        var command = new DissociateAutoCommand(persona, auto);
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
