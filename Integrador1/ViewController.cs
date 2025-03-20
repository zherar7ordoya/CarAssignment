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
        _persona = new PersonaRepository();
        _auto = new AutoRepository();
    }

    private readonly PersonaRepository _persona;
    private readonly AutoRepository _auto;

    public List<Persona> ObtenerPersonas()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(_persona.Read);
        return Success && Result != null ? Result : [];
    }

    public bool CrearPersona(string dni, string nombre, string apellido)
    {
        return SafeExecutor.Execute(() => _persona.CrearPersona(dni, nombre, apellido)).Success;
    }

    public bool ActualizarPersona(Persona persona)
    {
        return SafeExecutor.Execute(() => _persona.Update(persona)).Success;
    }

    public bool EliminarPersona(Persona persona)
    {
        return SafeExecutor.Execute(() => _persona.Delete(persona)).Success;
    }

    public static int ObtenerCantidadAutosDePersona(Persona persona)
    {
        return SafeExecutor.Execute(() => PersonaRepository.GetCantidadAutos(persona)).Result;
    }

    public static decimal ObtenerValorTotalAutosDePersona(Persona persona)
    {
        return SafeExecutor.Execute(() => PersonaRepository.GetValorAutos(persona)).Result;
    }

    public List<Auto> AutosDisponibles()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(_auto.Read);
        return Success && Result != null ? [.. Result.Where(auto => auto.DueñoId == 0)] : [];
    }

    public bool CrearAuto(string patente, string marca, string modelo, int año, decimal precio)
    {
        return SafeExecutor.Execute(() => _auto.CrearAuto(patente, marca, modelo, año, precio)).Success;
    }

    public bool ActualizarAuto(Auto auto)
    {
        return SafeExecutor.Execute(() => _auto.Update(auto)).Success;
    }

    public bool EliminarAuto(Auto auto)
    {
        return SafeExecutor.Execute(() => _auto.Delete(auto)).Success;
    }

    public static string ObtenerDueñoAuto(Persona persona)
    {
        return $"{persona.Apellido}, {persona.Nombre}";
    }

    public record AutoAsignado(string Marca,
                               int Año,
                               string Modelo,
                               string Patente,
                               string Documento,
                               string Dueño);

    public List<AutoAsignado> AutosAsignados()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(ObtenerPersonas);

        if (!Success || Result == null)
        {
            return [];
        }

        return [.. Result.SelectMany(persona => persona.Autos?.Select(auto =>
            new AutoAsignado(auto.Marca ?? "",
                             auto.Año,
                             auto.Modelo ?? "",
                             auto.Patente ?? "",
                             persona.DNI ?? "",
                             ObtenerDueñoAuto(persona))) ?? [])];
    }

    public static bool CargarDatos<T>(BindingSource source, Func<List<T>> obtenerDatos)
    {
        return SafeExecutor.Execute(() => source.DataSource = obtenerDatos()).Success;
    }

    public (bool Success, string ErrorMessage) AsignarAutoAPersona(Persona persona, Auto auto)
    {
        return SafeExecutor.Execute(() =>
        {
            AsignacionesManager.AsignarAuto(persona, auto);
            ActualizarPersona(persona);
            ActualizarAuto(auto);
        });
    }

    public (bool Success, string ErrorMessage) QuitarAutoDePersona(Persona persona, Auto auto)
    {
        return SafeExecutor.Execute(() =>
        {
            AsignacionesManager.DesasignarAuto(persona, auto);
            ActualizarPersona(persona);
            ActualizarAuto(auto);
        });
    }
}
