using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Interfaces;

using System.Reflection;

namespace Integrador.Infrastructure.Persistence.XML.Repository;

public class XmlRepository<T>
(
    IXmlContext<T> dataSource,
    IExceptionHandler exceptionHandler,
    IMessenger messenger,
    ILogger logger
) : IRepository<T> where T : IEntity
{
    public void Create(T entity)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            int nextId = entities.Count == 0 ? 1 : entities.Max(e => e.Id) + 1;
            entity.Id = nextId;
            entities.Add(entity);
            dataSource.Write(entities);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"Create completed for {entity}");
        }
    }

    public IEnumerable<T> ReadAll()
    {
        try
        {
            return dataSource.Read() ?? Enumerable.Empty<T>();
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error in {MethodBase.GetCurrentMethod()?.Name}");
            return [];
        }
    }

    public T? ReadById(int id)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            var entity = entities.FirstOrDefault(e => e.Id == id);

            if (entity == null) messenger.ShowInformation($"Entity with ID {id} not found.");

            return entity;
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error in {MethodBase.GetCurrentMethod()?.Name}");
            return default;
        }
    }

    public void Update(T entity)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            var index = entities.FindIndex(e => e.Id == entity.Id);
            entities[index] = entity;
            dataSource.Write(entities);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"Update completed for {entity}");
        }
    }

    public void Delete(int id)
    {
        var entities = dataSource.Read() ?? [];
        var entity = entities.FirstOrDefault(e => e.Id == id);

        try
        {
            if (entity == null) throw new Exception($"Entity with ID {id} not found.");
            entities.Remove(entity);
            dataSource.Write(entities);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            logger.TryLog($"Delete completed for {typeof(T).Name} with Id {id}");
        }
    }
}
