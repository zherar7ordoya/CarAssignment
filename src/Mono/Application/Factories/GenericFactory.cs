using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Factories;

public static class GenericFactory
{
    // Instancia un objeto de tipo T con el constructor por defecto.
    public static T Create<T>() where T : class, new()
    {
        return new T();
    }

    // Instancia un objeto de tipo T con los argumentos especificados.
    public static T? Create<T>(params object[] args) where T : class
    {
        return Activator.CreateInstance(typeof(T), args) as T;
    }
}
