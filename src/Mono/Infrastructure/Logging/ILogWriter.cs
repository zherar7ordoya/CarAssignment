using Integrador.Infrastructure.Logging.Shared;

namespace Integrador.Infrastructure.Logging;

public interface ILogWriter
{
    void Write(LogEntry entry);
}
