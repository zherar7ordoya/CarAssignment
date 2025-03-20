using Integrador.Abstract;

namespace Integrador.Infrastructure.Persistence;

public class Repository<T> : IRepository<T> where T : IEntity
{
    private readonly XmlDataSource<T> _database = new();

    public T Create(T entity)
    {
        var entities = _database.Read();
        entity.Id = entities.Count > 0 ? entities.Max(x => x.Id) + 1 : 1;
        entities.Add(entity);
        _database.Write(entities);
        return entity;
    }

    public bool Delete(T entity)
    {
        var entities = _database.Read();
        int removedCount = entities.RemoveAll(x => x.Id == entity.Id);
        return removedCount > 0 && _database.Write(entities);
    }

    public List<T> Read()
    {
        var entities = _database.Read();
        return entities;
    }

    public bool Update(T entity)
    {
        var entities = _database.Read();
        var entityToUpdate = entities.FirstOrDefault(x => x.Id == entity.Id);
        if (entityToUpdate == null) return false;

        var index = entities.IndexOf(entityToUpdate);
        if (index >= 0)
        {
            entities[index] = entity;
        }

        return _database.Write(entities);
    }
}
