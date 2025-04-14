using Integrador.Domain.Interfaces;

namespace Integrador.Infrastructure.Interfaces.Persistence;

public interface IRepository<T> where T : IEntity
{
    void Create(T entity);
    IEnumerable<T> ReadAll();
    T? ReadById(int id);
    void Update(T entity);
    void Delete(int id);
}
