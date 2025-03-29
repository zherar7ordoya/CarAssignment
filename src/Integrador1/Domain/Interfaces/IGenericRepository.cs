namespace Integrador.Domain.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    bool Create(T entity);
    List<T> GetAll();
    T? GetById(int id);
    bool Update(T entity);
    bool Delete(T entity);
}