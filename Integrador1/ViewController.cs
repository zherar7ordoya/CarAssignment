using Integrador.Abstract;
using Integrador.BusinessLogic;
using Integrador.Core;
using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador;

public class ViewController
{
    //private readonly PersonaRepository _personaRepository = new();
    //private readonly AutoRepository _autoRepository = new();

    #region OPERACIONES CRUD ***************************************************

    public record AutoAsignado(string Marca,
                               int Año,
                               string Modelo,
                               string Patente,
                               string Documento,
                               string Dueño);

    public static string GetApellidoNombre(Persona persona)
    {
        return $"{persona.Apellido}, {persona.Nombre}";
    }

    //..........................................................................

    public bool CreatePersona(string dni, string nombre, string apellido)
    {
        return SafeExecutor.Execute(() => _personaRepository.CreatePersona(dni, nombre, apellido)).Success;
    }

    public List<Persona> ReadPersonas()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(_personaRepository.Read);
        return Success && Result != null ? Result : [];
    }

    public bool UpdatePersona(Persona persona)
    {
        return SafeExecutor.Execute(() => _personaRepository.Update(persona)).Success;
    }

    public bool DeletePersona(Persona persona)
    {
        return SafeExecutor.Execute(() => _personaRepository.Delete(persona)).Success;
    }

    //..........................................................................

    public bool CreateAuto(string patente, string marca, string modelo, int año, decimal precio)
    {
        return SafeExecutor.Execute(() => _autoRepository.CreateAuto(patente, marca, modelo, año, precio)).Success;
    }

    public List<Auto> ReadAutosDisponibles()
    {
        var (Success, Result, ErrorMessage) = SafeExecutor.Execute(() => _autoRepository.ReadDisponibles());
        return Success && Result != null ? Result : [];
    }

    public static List<AutoAsignado> ReadAutosAsignados(List<Persona> personas)
    {
        return [.. personas
        .Where(persona => persona.Autos != null)
        .SelectMany(persona => persona.Autos
            .Select(auto => new AutoAsignado
            (
                auto.Marca ?? "Desconocido",
                auto.Año,
                auto.Modelo ?? "Desconocido",
                auto.Patente ?? "Sin patente",
                persona.DNI ?? "Sin DNI",
                GetApellidoNombre(persona)
            )))];
    }

    public bool UpdateAuto(Auto auto)
    {
        return SafeExecutor.Execute(() => _autoRepository.Update(auto)).Success;
    }

    public bool DeleteAuto(Auto auto)
    {
        return SafeExecutor.Execute(() => _autoRepository.Delete(auto)).Success;
    }

    #endregion *****************************************************************

    public static int GetCantidadAutos(Persona persona) => SafeExecutor.Execute(() => PersonaRepository.GetCantidadAutos(persona)).Result;
    public static decimal GetValorAutos(Persona persona) => SafeExecutor.Execute(() => PersonaRepository.GetValorAutos(persona)).Result;

    public static bool CargarDatos<T>(BindingSource source, Func<List<T>> obtenerDatos)
    {
        return SafeExecutor.Execute(() => source.DataSource = obtenerDatos(), "Error al cargar datos.").Success;
    }

    public (bool Success, string ErrorMessage) AsignarAuto(Persona persona, Auto auto)
    {
        return SafeExecutor.Execute(() =>
        {
            AsignacionesManager.AsignarAuto(persona, auto);
            UpdatePersona(persona);
            UpdateAuto(auto);
        });
    }

    public (bool Success, string ErrorMessage) DesasignarAuto(Persona persona, Auto auto)
    {
        return SafeExecutor.Execute(() =>
        {
            AsignacionesManager.DesasignarAuto(persona, auto);
            UpdatePersona(persona);
            UpdateAuto(auto);
        });
    }
}
