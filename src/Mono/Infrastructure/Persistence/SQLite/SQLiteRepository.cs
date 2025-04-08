using System.Data;

using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

using Microsoft.Data.Sqlite;

namespace Integrador.Infrastructure.Persistence.SQLite;

public class SQLiteRepository<T, TRecord>
(
    ISQLiteDataSource<T> sqliteDataSource,
    IMapper<T, TRecord> mapper
) : IRepository<T> where T : IEntity
{
    private readonly string _tableName = typeof(T).Name;

    public void Create(T entity)
    {
        if (entity.Id == 0)
        {
            var existing = ReadAll();
            int nextId = existing.Count == 0 ? 1 : existing.Max(e => e.Id) + 1;
            entity.Id = nextId;
        }

        var record = mapper.ToStorage(entity) ?? throw new InvalidOperationException("Record cannot be null."); // el record tiene las propiedades planas
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

        var recordType = typeof(TRecord) ?? throw new InvalidOperationException("Record type cannot be determined.");
        var properties = recordType.GetProperties();

        while (reader.Read())
        {
            var record = Activator.CreateInstance(recordType)!;

            foreach (var prop in properties)
            {
                var value = reader[prop.Name];
                if (value is DBNull) value = null;

                if (value != null)
                {
                    var targetType = prop.PropertyType;
                    var actualType = value.GetType();

                    // Soporte para Nullable<T>
                    var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                    if (actualType != underlyingType)
                    {
                        try
                        {
                            value = Convert.ChangeType(value, underlyingType);
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(
                                $"No se pudo convertir {prop.Name} de {actualType} a {underlyingType}", ex);
                        }
                    }
                }

                prop.SetValue(record, value);
            }

            var entity = mapper.ToDomain((TRecord)record);
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

        var recordType = typeof(TRecord) ?? throw new InvalidOperationException("Record type cannot be determined.");
        var properties = recordType.GetProperties();
        var record = Activator.CreateInstance(recordType)!;

        foreach (var prop in properties)
        {
            var value = reader[prop.Name];
            if (value is DBNull) value = null;

            if (value != null)
            {
                var targetType = prop.PropertyType;
                var actualType = value.GetType();

                // Soporte para Nullable<T>
                var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                if (actualType != underlyingType)
                {
                    try
                    {
                        value = Convert.ChangeType(value, underlyingType);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException(
                            $"No se pudo convertir {prop.Name} de {actualType} a {underlyingType}", ex);
                    }
                }
            }

            prop.SetValue(record, value);
        }

        return mapper.ToDomain((TRecord)record);
    }

    public void Update(T entity)
    {
        var record = mapper.ToStorage(entity) ?? throw new InvalidOperationException("Record cannot be null.");
        var recordType = record.GetType();
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

        var rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"Update failed: no record with Id {idValue} found.");
        }
    }

    public void Delete(int id)
    {
        var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";

        using var connection = sqliteDataSource.GetConnection();
        using var command = new SqliteCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", id);

        var rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
            throw new InvalidOperationException($"Update failed: no record with Id {id} found.");
        }
    }
}
