using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Interfaces;

public interface ISQLiteDataSource<T>
{
    SqliteConnection GetOpenConnection();
    string TableName { get; }
}
