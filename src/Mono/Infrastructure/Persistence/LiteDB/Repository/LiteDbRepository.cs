using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Interfaces;

using System.Reflection;

namespace Integrador.Infrastructure.Persistence.LiteDB.Repository;

public class LiteDbRepository<T>
(
    ILiteDbContext<T> dataSource,
    IExceptionHandler exceptionHandler,
    ILogger logger
) : IRepository<T> where T : class, IEntity, new()
{
    public void Create(T entity)
    {
        try
        {
            using var db = dataSource.GetDatabase();
            var collection = db.GetCollection<T>(dataSource.CollectionName);
            collection.Insert(entity); // Inserta y asigna Id automáticamente si es 0
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"LiteDB: Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"LiteDB: Create completed for {entity}");
        }
    }

    public IEnumerable<T> ReadAll()
    {
        try
        {
            using var db = dataSource.GetDatabase();
            var collection = db.GetCollection<T>(dataSource.CollectionName);
            return [.. collection.FindAll()];
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"LiteDB: Error in {MethodBase.GetCurrentMethod()?.Name}");
            return [];
        }
    }

    public T? ReadById(int id)
    {
        try
        {
            using var db = dataSource.GetDatabase();
            var collection = db.GetCollection<T>(dataSource.CollectionName);
            return collection.FindById(id);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"LiteDB: Error in {MethodBase.GetCurrentMethod()?.Name}");
            return default;
        }
    }

    public void Update(T entity)
    {
        try
        {
            using var db = dataSource.GetDatabase();
            var collection = db.GetCollection<T>(dataSource.CollectionName);
            if (!collection.Update(entity))
            {
                throw new Exception($"LiteDB: Could not update entity with Id {entity.Id}");
            }
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"LiteDB: Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"LiteDB: Update completed for {entity}");
        }
    }

    public void Delete(int id)
    {
        try
        {
            using var db = dataSource.GetDatabase();
            var collection = db.GetCollection<T>(dataSource.CollectionName);
            if (!collection.Delete(id))
            {
                throw new Exception($"LiteDB: Could not delete entity with Id {id}");
            }
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"LiteDB: Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"LiteDB: Delete completed for {typeof(T).Name} with Id {id}");
        }
    }
}
