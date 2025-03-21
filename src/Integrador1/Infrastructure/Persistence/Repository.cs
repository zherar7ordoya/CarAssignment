using Integrador.Abstract;

namespace Integrador.Infrastructure.Persistence;

public class Repository<T> : IRepository<T> where T : IEntity
{
    private readonly XmlDataSource<T> _xmlDataSource = new();

    public bool Create(T entity)
    {
        var entities = _xmlDataSource.Read();
        entities.Add(entity);
        return _xmlDataSource.Write(entities);
    }

    public bool Delete(T entity)
    {
        var entities = _xmlDataSource.Read();
        int removedCount = entities.RemoveAll(x => x.Id == entity.Id);
        return removedCount > 0 && _xmlDataSource.Write(entities);
    }

    public List<T> Read()
    {
        var entities = _xmlDataSource.Read();
        return entities;
    }

    public bool Update(T entity)
    {
        var entities = _xmlDataSource.Read();
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
        return _xmlDataSource.Write(entities);
    }
}
