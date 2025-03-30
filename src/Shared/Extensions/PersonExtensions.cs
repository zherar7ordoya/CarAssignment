using Integrador.Domain.Entities;

namespace Integrador.Shared.Extensions;

public static class PersonExtensions
{
    public static List<Car> GetListaAutos(this Person persona) => (List<Car>)persona.Autos;
    public static int GetCantidadAutos(this Person persona) => persona.Autos.Count;
    public static decimal GetValorAutos(this Person persona) => persona.Autos.Sum(auto => auto.Precio);
    public static string GetApellidoNombre(this Person persona) => $"{persona.Apellido}, {persona.Nombre}";
    public static string GetDNI(this Person persona) => persona.DNI;
}
