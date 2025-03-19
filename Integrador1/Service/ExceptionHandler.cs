using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Service;

public static class ExceptionHandler
{
    public static void ManejarExcepcion(string mensaje, Exception ex)
    {
        Logger.LogError(mensaje, ex);
        Messenger.MostrarError(mensaje, ex);
    }
}
