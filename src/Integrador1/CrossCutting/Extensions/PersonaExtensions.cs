using Integrador.Entities;

namespace Integrador.CrossCutting.Extensions;

public static class PersonaExtensions
{
    public static List<Auto> GetListaAutos(this Persona persona) => persona.Autos;
    public static int GetCantidadAutos(this Persona persona) => persona.Autos.Count;
    public static decimal GetValorAutos(this Persona persona) => persona.Autos.Sum(auto => auto.Precio);
    public static string GetApellidoNombre(this Persona persona) => $"{persona.Apellido}, {persona.Nombre}";
}
