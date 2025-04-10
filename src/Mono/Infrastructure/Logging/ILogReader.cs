using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Logging;

public interface ILogReader
{
    IEnumerable<LogEntry> LeerTodos();
}
