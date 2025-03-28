namespace Integrador.Domain.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    T Create(T entity);
    List<T> GetAll();
    bool Update(T entity);
    bool Delete(T entity);
}
