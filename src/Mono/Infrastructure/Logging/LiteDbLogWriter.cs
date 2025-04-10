using LiteDB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Infrastructure.Logging;

public class LiteDbLogWriter(string connectionString) : ILogWriter
{
    public void Escribir(LogEntry entry)
    {
        using var db = new LiteDatabase(connectionString);
        var col = db.GetCollection<LogEntry>("log");
        col.Insert(entry);
    }
}
