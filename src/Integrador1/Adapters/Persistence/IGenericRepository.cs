using Integrador.Entities;

namespace Integrador.Adapters.Persistence;

public interface IGenericRepository<T> where T : IPersistentEntity
{
    bool Create(T entity);
    List<T> Read();
    bool Update(T entity);
    bool Delete(T entity);
}
