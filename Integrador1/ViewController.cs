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
    private List<Auto> ObtenerAutos()
    {
        return _autoManager.Read();
    }

    public List<Auto> AutosDisponibles()
    {
        var autosDisponibles = ObtenerAutos()
            .Where(auto => auto.DueñoId == 0)
            .Select(auto => new Auto
            {
                Id = auto.Id,
                Patente = auto.Patente,
                Marca = auto.Marca,
                Modelo = auto.Modelo,
                Año = auto.Año,
                Precio = auto.Precio
            })
            .ToList();

        return autosDisponibles;
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

    // Métodos para Asignaciones.-----------------------------------------------
    public static void AsignarAutoAPersona(Persona persona, Auto auto)
    {
        AsignacionesManager.AsignarAuto(persona, auto);
    }

    public static void DesasignarAutoDePersona(Persona persona, Auto auto)
    {
        AsignacionesManager.DesasignarAuto(persona, auto);
    }

    public List<object> AutosAsignados()
    {
        var autosAsignados = ObtenerPersonas()
            .SelectMany(persona => persona.Autos.Select(auto => new
            {
                auto.Marca,
                auto.Año,
                auto.Modelo,
                auto.Patente,
                Documento = persona.DNI,
                Dueño = ObtenerDueñoAuto(persona)
            }))
            .ToList();
        return [.. autosAsignados.Cast<object>()];
    }
}
