using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Logging;

public class LogEntry
{
    public DateTime Timestamp { get; set; }
    public string Nivel { get; set; } = "Info";
    public string Mensaje { get; set; } = string.Empty;
    public string? StackTrace { get; set; }
    public string? Fuente { get; set; }
}
