using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Logging;

public class LiteDbLogReader(string connectionString) : ILogReader
{
    public IEnumerable<LogEntry> LeerTodos()
    {
        using var db = new LiteDatabase(connectionString);
        return db.GetCollection<LogEntry>("log").FindAll().OrderByDescending(e => e.Timestamp);
    }
}
