using Integrador.CrossCutting;
using Integrador.Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Core;

public static class PersonaExtensions
{
    public static int GetCantidadAutos(this Persona persona) => SafeExecutor.Execute(() => PersonaRepository.GetCantidadAutos(persona)).Result;
    public static decimal GetValorAutos(this Persona persona) => SafeExecutor.Execute(() => PersonaRepository.GetValorAutos(persona)).Result;
}
