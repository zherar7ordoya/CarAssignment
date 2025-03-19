using Integrador.Entities;
using Integrador.Logic;

namespace Integrador;

public class ViewController
{
    public ViewController()
    {
        _personaManager = new PersonaManager();
        _autoManager = new AutoManager();
    }

    private readonly PersonaManager _personaManager;
    private readonly AutoManager _autoManager;

    // Métodos para Personas.---------------------------------------------------
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
        return PersonaManager.GetCantidadAutos(persona);
    }

    public static decimal ObtenerValorTotalAutosDePersona(Persona persona)
    {
        return PersonaManager.GetValorAutos(persona);
    }

    // Métodos para Autos.------------------------------------------------------
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

    /* Para cumplir con lo pedido en el enunciado. */
    public static string ObtenerDueñoAuto(Persona persona)
    {
        return $"{persona.Apellido}, {persona.Nombre}";
    }

    public static string ObtenerDueñoAuto(Auto auto)
    {
        return auto.DueñoId == 0 ? "Sin asignar" : $"{auto.Dueño?.Apellido}, {auto.Dueño?.Nombre}";
    }




    // Métodos para Asignaciones.-----------------------------------------------
    public static void AsignarAutoAPersona(Persona persona, Auto auto)
    {
        AsignacionesManager.AsignarAuto(persona, auto);
    }

    public static void DesasignarAutoDePersona(Persona persona, Auto auto)
    {
        AsignacionesManager.DesasignarAuto(persona, auto);
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

}
