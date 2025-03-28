using Integrador.Domain.Interfaces;

namespace Integrador.Infrastructure.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : IEntity
{
    private readonly DataSource<T> _dataSource = new();

    public bool Create(T entity)
    {
        var entities = _dataSource.Read();
        entities.Add(entity);
        return _dataSource.Write(entities);
    }

    public bool Delete(T entity)
    {
        var entities = _dataSource.Read();
        int removedCount = entities.RemoveAll(x => x.Id == entity.Id);
        return removedCount > 0 && _dataSource.Write(entities);
    }

    public List<T> Read()
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
