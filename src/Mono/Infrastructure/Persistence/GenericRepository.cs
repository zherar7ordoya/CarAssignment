using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;

using System.Reflection;

namespace Integrador.Infrastructure.Persistence;

public class GenericRepository<T>
(
    IDataSource<T> dataSource,
    IExceptionHandler exceptionHandler,
    ILogger logger
) : IGenericRepository<T> where T : IEntity
{
    public bool Create(T entity)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            int nextId = entities.Count == 0 ? 1 : entities.Max(e => e.Id) + 1;
            entity.Id = nextId;
            entities.Add(entity);
            return dataSource.Write(entities);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error en {MethodBase.GetCurrentMethod()?.Name}");
            return false;
        }
        finally
        {
            TryLog($"CreateAsync completed for entity with ID: {entity.Id}");
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            if (entities.Count == 0) return false;
            bool removed = entities.RemoveAll(e => e.Id == id) > 0;
            return removed && dataSource.Write(entities);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error en {MethodBase.GetCurrentMethod()?.Name}");
            return false;
        }
        finally
        {
            TryLog($"DeleteAsync completed for entity with ID: {id}");
        }
    }

    public List<T> GetAll()
    {
        try
        {
            return dataSource.Read() ?? [];
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error en {MethodBase.GetCurrentMethod()?.Name}");
            return [];
        }
        finally
        {
            TryLog("GetAllAsync completed");
        }
    }

    public T? GetById(int id)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            var entity = entities.FirstOrDefault(e => e.Id == id);

            if (entity == null) TryLog($"GetByIdAsync: Entity with ID {id} not found.");
            else TryLog($"GetByIdAsync completed for entity with ID: {id}");

            return entity;
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error en {MethodBase.GetCurrentMethod()?.Name}");
            return default;
        }
    }

    public bool Update(T entity)
    {
        try
        {
            var entities = dataSource.Read() ?? [];
            var index = entities.FindIndex(e => e.Id == entity.Id);
            if (index == -1) return false;
            if (entities[index].Id != entity.Id) return false;
            entities[index] = entity;
            return dataSource.Write(entities);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error en {MethodBase.GetCurrentMethod()?.Name}");
            return false;
        }
        finally
        {
            TryLog($"UpdateAsync completed for entity with ID: {entity.Id}");
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
            System.Diagnostics.Debug.WriteLine($"Error al intentar loguear: {logEx.Message}");
        }
    }
}
