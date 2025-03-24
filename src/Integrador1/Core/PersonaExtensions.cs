using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

namespace Integrador.Core;

public static class PersonaExtensions
{
    public static int GetCantidadAutos(this Persona persona) => SafeExecutor.Execute(() => PersonaRepository.GetCantidadAutos(persona)).Result;
    public static decimal GetValorAutos(this Persona persona) => SafeExecutor.Execute(() => PersonaRepository.GetValorAutos(persona)).Result;
}
