using Integrador.BusinessLogic.Commands;
using Integrador.BusinessLogic.Commands.Asignaciones;
using Integrador.BusinessLogic.Commands.Autos;
using Integrador.BusinessLogic.Commands.Personas;
using Integrador.Core;
using Integrador.CrossCutting;

using System.Windows.Forms;

namespace Integrador;

public partial class ViewController
{

    #region OPERACIONES CRUD ***************************************************

    public static string GetApellidoNombre(Persona persona)
    {
        return $"{persona.Apellido}, {persona.Nombre}";
    }

    //..........................................................................

    public static List<Persona> ListarPersonas()
    {
        var command = new ReadPersonasCommand();
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success && Result.Result != null)
        {
            return Result.Result;
        }
        else
        {
            ExceptionHandler.HandleException("Error al listar personas.", new Exception(ErrorMessage));
            return [];
        }
    }

    public static void NuevoPersona(BindingSource personasBS, Button nuevoPersonaButton)
    {
        var nuevoPersona = new Persona();
        var (Success, ErrorMessage) = SafeExecutor.Execute(() =>
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
            ExceptionHandler.HandleException("Error al crear una nueva persona.", new Exception(ErrorMessage));
        }
    }

    public static void GuardarPersona(Persona persona, BindingSource personasBS)
    {
        IWriteCommand command = persona.Id == 0
            ? new CreatePersonaCommand(persona)
            : new UpdatePersonaCommand(persona);

        var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success)
        {
            personasBS.ResetBindings(false); // Actualizar la lista de personas
        }
        else
        {
            ExceptionHandler.HandleException("Error al guardar la persona.", new Exception(ErrorMessage));
        }
    }

    public static void EliminarPersona(Persona persona, BindingSource personasBS)
    {
        var command = new DeletePersonaCommand(persona);
        var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success)
        {
            personasBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException("Error al eliminar la persona.", new Exception(ErrorMessage));
        }
    }

    //..........................................................................

    public static List<Auto> ListarAutosDisponibles()
    {
        var command = new ReadAutosDisponiblesCommand();
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success && Result.Result != null)
        {
            return Result.Result;
        }
        else
        {
            ExceptionHandler.HandleException("Error al listar autos disponibles.", new Exception(ErrorMessage));
            return [];
        }
    }

    public static List<AutoAsignado> ListarAutosAsignados()
    {
        var command = new ReadAutosAsignadosCommand();
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success && Result.Result != null)
        {
            return Result.Result;
        }
        else
        {
            ExceptionHandler.HandleException("Error al listar autos asignados.", new Exception(ErrorMessage));
            return [];
        }
    }

    public static void NuevoAuto(BindingSource autosDisponiblesBS, Button nuevoAutoButton)
    {
        var nuevoAuto = new Auto();
        var (Success, ErrorMessage) = SafeExecutor.Execute(() =>
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
            ExceptionHandler.HandleException("Error al crear una nueva persona.", new Exception(ErrorMessage));
        }
    }

    public static void GuardarAuto(Auto auto, BindingSource autosDisponiblesBS)
    {
        IWriteCommand command = auto.Id == 0
            ? new CreateAutoCommand(auto)
            : new UpdateAutoCommand(auto);

        var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success)
        {
            autosDisponiblesBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException("Error al guardar el auto.", new Exception(ErrorMessage));
        }
    }

    public static void EliminarAuto(Auto auto, BindingSource autosDisponiblesBS)
    {
        var command = new DeleteAutoCommand(auto);
        var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success)
        {
            autosDisponiblesBS.ResetBindings(false);
        }
        else
        {
            ExceptionHandler.HandleException("Error al eliminar el auto.", new Exception(ErrorMessage));
        }
    }

    #endregion *****************************************************************

    public static void AsignarAuto(Persona persona,
                                   Auto auto,
                                   Action<Persona, Auto> onSuccess)
    {
        var command = new AsignarAutoCommand(persona, auto);
        var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success) { onSuccess?.Invoke(persona, auto); }
        else { ExceptionHandler.HandleException("Error al asignar un auto a una persona.", new Exception(ErrorMessage)); }
    }

    public static void DesasignarAuto(Persona persona,
                                      Auto auto,
                                      Action<Persona, Auto> onSuccess)
    {
        var command = new DesasignarAutoCommand(persona, auto);
        var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

        if (Success) { onSuccess?.Invoke(persona, auto); }
        else { ExceptionHandler.HandleException("Error al quitar un auto de una persona.", new Exception(ErrorMessage)); }
    }
}
