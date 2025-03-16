using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador;

public static class Service
{
    public static void LogError(string message, Exception ex)
    {
        var logMessage = $"[{DateTime.Now}] {message} - Excepción: {ex.GetType().Name}, Mensaje: {ex.Message}";
        File.AppendAllText("Log.txt", logMessage + Environment.NewLine);
    }
}
