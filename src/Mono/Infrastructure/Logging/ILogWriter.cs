using Integrador.Infrastructure.Logging.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Logging;

public interface ILogWriter
{
    void Write(LogEntry entry);
}
