using Integrador.Application.Interfaces.Persistence;
using Integrador.Domain.Interfaces;

namespace Integrador.Infrastructure.Persistence.LiteDB.Repository;

public class LiteDbRepository<T>
(
    ILiteDbContext<T> dataSource
) : IRepository<T> where T : class, IEntity, new()
{
    public void Create(T entity)
    {
        using var db = dataSource.GetDatabase();
        var collection = db.GetCollection<T>(dataSource.CollectionName);
        collection.Insert(entity); // Inserta y asigna Id automáticamente si es 0
    }

    public IEnumerable<T> ReadAll()
    {
        using var db = dataSource.GetDatabase();
        var collection = db.GetCollection<T>(dataSource.CollectionName);
        return [.. collection.FindAll()];
    }

    public T? ReadById(int id)
    {
        using var db = dataSource.GetDatabase();
        var collection = db.GetCollection<T>(dataSource.CollectionName);
        return collection.FindById(id);
    }

    public void Update(T entity)
    {
        using var db = dataSource.GetDatabase();
        var collection = db.GetCollection<T>(dataSource.CollectionName);
        if (!collection.Update(entity))
        {
            throw new Exception($"No se pudo actualizar la entidad con Id {entity.Id}");
        }
    }

    public void Delete(int id)
    {
        using var db = dataSource.GetDatabase();
        var collection = db.GetCollection<T>(dataSource.CollectionName);
        if (!collection.Delete(id))
        {
            throw new Exception($"No se pudo eliminar la entidad con Id {id}");
        }
    }
}
