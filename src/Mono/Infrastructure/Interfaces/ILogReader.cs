using Integrador.Infrastructure.Logging.Shared;

namespace Integrador.Infrastructure.Interfaces;

public interface ILogReader
{
    IEnumerable<LogEntry> Read();
}
