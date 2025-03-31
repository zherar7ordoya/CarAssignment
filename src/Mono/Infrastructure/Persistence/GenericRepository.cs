using Integrador.Domain.Exceptions;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Interfaces;

namespace Integrador.Infrastructure.Persistence;

public class GenericRepository<T>(IDataSource<T> dataSource)
    : IGenericRepository<T> where T : IEntity
{
    private readonly IDataSource<T> _dataSource = dataSource;

    public async Task<bool> CreateAsync(T entity, CancellationToken ct = default)
    {
        var entities = await _dataSource.ReadAsync(ct) ?? [];
        int nextId = entities.Count == 0 ? 1 : entities.Max(e => e.Id) + 1;
        entity.Id = nextId; // Si IEntity tiene setter público (requerido por XML)
        entities.Add(entity);
        return await _dataSource.WriteAsync(entities, ct);
    }

    public async Task<bool> DeleteAsync(T entity, CancellationToken ct)
    {
        try
        {
            var entities = await _dataSource.ReadAsync(ct);
            var removed = entities.RemoveAll(e => e.Id == entity.Id) > 0;
            return removed && await _dataSource.WriteAsync(entities, ct);
        }
        catch (Exception ex)
        {
            throw new DomainException("Error eliminando entidad", ex);
        }
    }

    public async Task<List<T>> GetAllAsync(CancellationToken ct)
    {
        return await _dataSource.ReadAsync(ct);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken ct)
    {
        var entities = await _dataSource.ReadAsync(ct);
        return entities.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken ct)
    {
        try
        {
            var entities = await _dataSource.ReadAsync(ct);
            var index = entities.FindIndex(e => e.Id == entity.Id);
            if (index == -1) return false;
            entities[index] = entity;
            return await _dataSource.WriteAsync(entities, ct);
        }
        catch (Exception ex)
        {
            throw new DomainException("Error actualizando entidad", ex);
        }
    }
}
