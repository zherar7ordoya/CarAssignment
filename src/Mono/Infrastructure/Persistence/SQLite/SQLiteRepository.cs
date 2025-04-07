using System.Data;

using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

using Microsoft.Data.Sqlite;

namespace Integrador.Infrastructure.Persistence.SQLite;

public class SQLiteRepository<T>
(
    SQLiteDataSource<T> sqliteDataSource,
    IMapper<T, object> mapper
) : IRepository<T> where T : IEntity
{
    private readonly string _tableName = typeof(T).Name;

    public void Create(T entity)
    {
        var record = toRecord(entity); // el record tiene las propiedades planas
        var recordType = record.GetType();
        var properties = recordType.GetProperties();

        var columnNames = string.Join(", ", properties.Select(p => p.Name));
        var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));
        var sql = $"INSERT INTO {_tableName} ({columnNames}) VALUES ({parameterNames})";

        using var connection = sqliteDataSource.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        foreach (var property in properties)
        {
            var name = "@" + property.Name;
            var value = property.GetValue(record) ?? DBNull.Value;
            command.Parameters.AddWithValue(name, value);
        }

        command.ExecuteNonQuery();
    }

    public List<T> ReadAll()
    {
        var results = new List<T>();
        var sql = $"SELECT * FROM {_tableName}";

        using var connection = sqliteDataSource.GetConnection();
        using var command = new SqliteCommand(sql, connection);
        using var reader = command.ExecuteReader();

        var recordType = toRecord(default!)!.GetType();
        var properties = recordType.GetProperties();

        while (reader.Read())
        {
            var record = Activator.CreateInstance(recordType)!;

            foreach (var prop in properties)
            {
                var value = reader[prop.Name];
                if (value is DBNull) value = null;
                prop.SetValue(record, value);
            }

            var entity = toEntity(record);
            results.Add(entity);
        }

        return results;
    }

    public T? ReadById(int id)
    {
        var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";

        using var connection = sqliteDataSource.GetConnection();
        using var command = new SqliteCommand(sql, connection);
        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();

        if (!reader.Read()) return default;

        var recordType = toRecord(default!)!.GetType();
        var properties = recordType.GetProperties();
        var record = Activator.CreateInstance(recordType)!;

        foreach (var prop in properties)
        {
            var value = reader[prop.Name];
            if (value is DBNull) value = null;
            prop.SetValue(record, value);
        }

        return toEntity(record);
    }

    public void Update(T entity)
    {
        var record = toRecord(entity);
        var recordType = record!.GetType();
        var properties = recordType.GetProperties().Where(p => p.Name != "Id").ToArray(); // No se actualiza el Id

        var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
        var sql = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";

        using var connection = sqliteDataSource.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        foreach (var prop in properties)
        {
            var name = "@" + prop.Name;
            var value = prop.GetValue(record) ?? DBNull.Value;
            command.Parameters.AddWithValue(name, value);
        }

        // Agregamos el parámetro Id al final
        var idProp = recordType.GetProperty("Id");
        var idValue = idProp?.GetValue(record) ?? throw new InvalidOperationException("Entity must have an Id");
        command.Parameters.AddWithValue("@Id", idValue);

        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";

        using var connection = sqliteDataSource.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", id);

        command.ExecuteNonQuery();
    }
}
