using System.Data;
using System.Reflection;

using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Interfaces;

using Microsoft.Data.Sqlite;

namespace Integrador.Infrastructure.Persistence.SQLite.Repository;

public class SQLiteRepository<T, TRecord>
(
    ISQLiteContext<T> sqliteDataSource,
    IMapper<T, TRecord> mapper,
    IExceptionHandler exceptionHandler,
    ILogger logger
) : IRepository<T> where T : IEntity
{
    private readonly string _tableName = typeof(T).Name;

    /* ////////////////////////////////////////////////////////////////////// */

    public void Create(T entity)
    {
        try
        {
            if (entity.Id == 0)
            {
                var existing = ReadAll();
                int nextId = !existing.Any() ? 1 : existing.Max(e => e.Id) + 1;
                entity.Id = nextId;
            }

            // El record tiene las propiedades planas
            var record = mapper.ToStorage(entity)
                     ?? throw new InvalidOperationException("SQLite: Record cannot be null.");
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
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"SQLite: Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"SQLite: Create completed for {entity}");
        }
    }

    public IEnumerable<T> ReadAll()
    {
        try
        {
            var results = new List<T>();
            var sql = $"SELECT * FROM {_tableName}";

            using var connection = sqliteDataSource.GetConnection();
            using var command = new SqliteCommand(sql, connection);
            using var reader = command.ExecuteReader();

            var recordType = typeof(TRecord)
                     ?? throw new InvalidOperationException("SQLite: Record type cannot be determined.");
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

                        var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                        if (actualType != underlyingType)
                        {
                            try
                            {
                                value = Convert.ChangeType(value, underlyingType);
                            }
                            catch (Exception ex)
                            {
                                throw new InvalidOperationException
                                (
                                    $"SQLite: Error converting {prop.Name} from {actualType} to {underlyingType}", ex
                                );
                            }
                        }
                    }

                    prop.SetValue(record, value);
                }

                var entity = mapper.ToDomain((TRecord)record);
                results.Add(entity);
            }

            return results; // Como IEnumerable<T>
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"SQLite: Error in {MethodBase.GetCurrentMethod()?.Name}");
            return [];
        }
    }

    public T? ReadById(int id)
    {
        try
        {
            var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";

            using var connection = sqliteDataSource.GetConnection();
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return default;

            var recordType = typeof(TRecord)
                         ?? throw new InvalidOperationException("SQLite: Record type cannot be determined.");
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
                            throw new InvalidOperationException
                            (
                                $"SQLite: Error converting {prop.Name} from {actualType} to {underlyingType}", ex
                            );
                        }
                    }
                }

                prop.SetValue(record, value);
            }

            return mapper.ToDomain((TRecord)record);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"SQLite: Error in {MethodBase.GetCurrentMethod()?.Name}");
            return default;
        }
    }

    public void Update(T entity)
    {
        try
        {
            var record = mapper.ToStorage(entity)
                     ?? throw new InvalidOperationException("SQLite: Record cannot be null.");
            var recordType = record.GetType();

            // No se actualiza el Id
            var properties = recordType.GetProperties().Where(p => p.Name != "Id").ToArray();

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
            var idValue = idProp?.GetValue(record)
                      ?? throw new InvalidOperationException("SQLite: Entity must have an Id");
            command.Parameters.AddWithValue("@Id", idValue);

            var rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                throw new InvalidOperationException($"SQLite: Update failed (no record with Id {idValue} found).");
            }
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"SQLite: Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"SQLite: Update completed for {entity}");
        }
    }

    public void Delete(int id)
    {
        try
        {
            var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";

            using var connection = sqliteDataSource.GetConnection();
            using var command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);

            var rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                throw new InvalidOperationException($"SQLite: Update failed (no record with Id {id} found).");
            }
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"SQLite: Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"SQLite: Delete completed for {typeof(T).Name} with Id {id}");
        }
    }
}
