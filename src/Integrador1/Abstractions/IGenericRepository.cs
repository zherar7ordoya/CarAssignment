namespace Integrador.Abstractions;

public interface IGenericRepository<T> where T : IEntity
{
    bool Create(T entity);
    List<T> Read();
    bool Update(T entity);
    bool Delete(T entity);
}
