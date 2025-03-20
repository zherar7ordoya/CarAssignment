using Integrador.Abstract;
using Integrador.BusinessLogic;
using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador;

public class ViewController
{
    public ViewController()
    {
        _personaManager = new PersonaRepository();
        _autoManager = new AutoRepository();
    }

    private readonly PersonaRepository _personaManager;
    private readonly AutoRepository _autoManager;

    public List<Persona> ObtenerPersonas()
    {
        return _personaManager.Read();
    }

    public bool CrearPersona(string dni, string nombre, string apellido)
    {
        return _personaManager.CrearPersona(dni, nombre, apellido);
    }

    public bool ActualizarPersona(Persona persona)
    {
        return _personaManager.Update(persona);
    }

    public bool EliminarPersona(Persona persona)
    {
        return _personaManager.Delete(persona);
    }

    public static int ObtenerCantidadAutosDePersona(Persona persona)
    {
        return PersonaRepository.GetCantidadAutos(persona);
    }

    public static decimal ObtenerValorTotalAutosDePersona(Persona persona)
    {
        return PersonaRepository.GetValorAutos(persona);
    }

    public List<Auto> AutosDisponibles()
    {
        return [.. _autoManager.Read().Where(auto => auto.DueñoId == 0)];
    }

    public bool CrearAuto(string patente, string marca, string modelo, int año, decimal precio)
    {
        return _autoManager.CrearAuto(patente, marca, modelo, año, precio);
    }

    public bool ActualizarAuto(Auto auto)
    {
        return _autoManager.Update(auto);
    }

    public bool EliminarAuto(Auto auto)
    {
        return _autoManager.Delete(auto);
    }

    public static string ObtenerDueñoAuto(Persona persona)
    {
        return $"{persona.Apellido}, {persona.Nombre}";
    }


    /* SIN REFERENCIAS... */
    public static string ObtenerDueñoAuto(Auto auto)
    {
        return auto.DueñoId == 0 ? "Sin asignar" : $"{auto.Dueño?.Apellido}, {auto.Dueño?.Nombre}";
    }


    public record AutoAsignado(string Marca, int Año, string Modelo, string Patente, string Documento, string Dueño);

    public List<AutoAsignado> AutosAsignados()
    {
        return [.. ObtenerPersonas()
                .SelectMany(persona => persona.Autos.Select(auto =>
                new AutoAsignado(auto.Marca ?? "",
                                 auto.Año,
                                 auto.Modelo ?? "",
                                 auto.Patente ?? "",
                                 persona.DNI ?? "",
                                 ObtenerDueñoAuto(persona))))];
    }

    public static void NuevoObjeto<T>(BindingSource source, T nuevoObjeto, Button boton)
    {
        source.Add(nuevoObjeto);
        source.MoveLast();
        boton.Enabled = false;
    }


    /* SIN REFERENCIAS... */
    public static void GuardarEntidad<T>(BindingSource source,
                                          Action<T> actualizar,
                                          Action<T> crear,
                                          Action recargar,
                                          Button boton) where T : IEntity
    {
        try
        {
            if (source.Current is T entidad)
            {
                (entidad.Id == 0 ? crear : actualizar)(entidad);
                recargar();
            }
        }
        catch (Exception ex) { Exceptor.HandleException("Error al guardar.", ex); }
        finally { boton.Enabled = true; }
    }


    /* SIN REFERENCIAS... */
    public static void EliminarObjeto<T>(BindingSource source,
                                          Func<T, bool> eliminar,
                                          Action recargar)
    {
        if (Messenger.MostrarConfirmacion("¿Está seguro que desea eliminar la entidad seleccionada?", "Confirmación"))
        {
            if (source.Current is T objetoSeleccionado)
            {
                eliminar(objetoSeleccionado);
                recargar();
            }
        }
    }


    public static void CargarDatos<T>(BindingSource source, Func<List<T>> obtenerDatos)
    {
        try { source.DataSource = obtenerDatos(); }
        catch (Exception ex) { Exceptor.HandleException("Error al cargar datos.", ex); }
    }

    public (bool Success, string ErrorMessage) AsignarAutoAPersona(Persona persona, Auto auto)
    {
        try
        {
            AsignacionesManager.AsignarAuto(persona, auto);
            ActualizarPersona(persona);
            ActualizarAuto(auto);
            return (true, string.Empty); // Éxito
        }
        catch (Exception ex)
        {
            return (false, ex.Message); // Error
        }
    }

    public (bool Success, string ErrorMessage) QuitarAutoDePersona(Persona persona, Auto auto)
    {
        try
        {
            AsignacionesManager.DesasignarAuto(persona, auto);
            ActualizarPersona(persona);
            ActualizarAuto(auto);
            return (true, string.Empty); // Éxito
        }
        catch (Exception ex)
        {
            return (false, ex.Message); // Error
        }
    }
}
