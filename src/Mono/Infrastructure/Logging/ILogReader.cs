using Integrador.Infrastructure.Logging.Shared;

namespace Integrador.Infrastructure.Logging;

public interface ILogReader
{
    IEnumerable<LogEntry> Read();
}
