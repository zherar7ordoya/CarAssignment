using Integrador.Domain.Interfaces;

namespace Integrador.Infrastructure.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
{
    private readonly DataSource<T> _dataSource = new();

    public bool Create(T entity)
    {
        var entities = GetAll();
        entity.Id = entities.Count == 0 ? 1 : entities.Max(e => e.Id) + 1;
        entities.Add(entity);
        return _dataSource.Write(entities);
    }

    public bool Delete(T entity)
    {
        var entities = _dataSource.Read();
        int removedCount = entities.RemoveAll(x => x.Id == entity.Id);
        return removedCount > 0 && _dataSource.Write(entities);
    }

    public List<T> GetAll()
    {
        var entities = _dataSource.Read();
        return entities;
    }

    public bool Update(T entity)
    {
        var entities = _dataSource.Read();
        var entityToUpdate = entities.FirstOrDefault(x => x.Id == entity.Id);

        if (entityToUpdate == null)
        {
            return false;
        }

        var index = entities.IndexOf(entityToUpdate);

        if (index < 0)
        {
            return false;
        }

        entities[index] = entity;
        return _dataSource.Write(entities);
    }
}
