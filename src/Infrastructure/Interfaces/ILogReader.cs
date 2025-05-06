using CarAssignment.Infrastructure.Logging.Shared;

namespace CarAssignment.Infrastructure.Interfaces;

public interface ILogReader
{
    IEnumerable<LogEntry> Read();
}
