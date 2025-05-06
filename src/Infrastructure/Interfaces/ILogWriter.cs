using CarAssignment.Infrastructure.Logging.Shared;

namespace CarAssignment.Infrastructure.Interfaces;

public interface ILogWriter
{
    void Write(LogEntry entry);
}
