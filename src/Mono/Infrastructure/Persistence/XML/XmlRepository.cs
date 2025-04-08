using Integrador.Application.Interfaces;

using System.Reflection;

namespace Integrador.Infrastructure.Persistence.XML;

// TODO: Mover logging a services.

public class XmlRepository<T>
(
    IXmlDataSource<T> dataSource,
    IExceptionHandler exceptionHandler,
    IMessenger messenger,
    ILogger logger
) : IRepository<T> where T : Domain.Entities.IEntity
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
            TryLog($"Create completed for {entity}");
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
            TryLog($"Delete completed for {entity}");
        }
    }

    public List<T> ReadAll()
    {
        try
        {
            return dataSource.Read() ?? [];
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
            TryLog($"Update completed for {entity}");
        }
    }

    /* ////////////////////////////////////////////////////////////////////// */

    /*
    Sí, el catch dentro de TryLog queda vacío a propósito, para evitar que un
    error en el logger o en su configuración oculte errores más importantes.
    Si el logger.LogInformation o logger.LogError falla por cualquier motivo
    (por ejemplo, si el logger no está correctamente inyectado o hay un problema
    con el almacenamiento de logs), no queremos que eso interrumpa la ejecución
    del programa ni que tape la verdadera excepción.
    Es una práctica común en logging evitar que los errores de logging generen
    más problemas.
     */
    private void TryLog(string message, Exception? ex = null)
    {
        try
        {
            if (ex is null) logger.LogInformation(message);
            else logger.LogError(ex, message);
        }
        catch (Exception logEx)
        {
            System.Diagnostics.Debug.WriteLine($"Logging error: {logEx.Message}");
        }
    }
}
