using Integrador.Application.Interfaces;

namespace Integrador.Infrastructure.Persistence;

public class GenericRepository<T>(IDataSource<T> dataSource)
           : IGenericRepository<T> where T : IEntity
{
    public async Task<bool> CreateAsync(T entity, CancellationToken ct = default)
    {
        var entities = await dataSource.ReadAsync(ct) ?? [];
        int nextId = entities.Count == 0 ? 1 : entities.Max(e => e.Id) + 1;
        entity.Id = nextId; // Si IEntity tiene setter público (requerido por XML)
        entities.Add(entity);
        return await dataSource.WriteAsync(entities, ct);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        try
        {
            var entities = await dataSource.ReadAsync(ct);
            var removed = entities.RemoveAll(e => e.Id == id) > 0;
            return removed && await dataSource.WriteAsync(entities, ct);
        }
        catch (Exception ex)
        {
            throw new Exception("Error eliminando entidad", ex);
        }
    }

    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return await dataSource.ReadAsync(ct);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken ct)
    {
        var entities = await dataSource.ReadAsync(ct);
        return entities.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken ct)
    {
        try
        {
            var entities = await dataSource.ReadAsync(ct);
            var index = entities.FindIndex(e => e.Id == entity.Id);
            if (index == -1) return false;
            entities[index] = entity;
            return await dataSource.WriteAsync(entities, ct);
        }
        catch (Exception ex)
        {
            throw new Exception("Error actualizando entidad", ex);
        }
    }
}
