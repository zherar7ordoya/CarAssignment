using Integrador.Infrastructure.Logging.Shared;

namespace Integrador.Infrastructure.Interfaces;

public interface ILogWriter
{
    void Write(LogEntry entry);
}
