namespace Integrador.Application.Interfaces;

public interface IRepository<T> where T : Domain.Entities.IEntity
{
    void Create(T entity);
    List<T> ReadAll();
    T? ReadById(int id);
    void Update(T entity);
    void Delete(int id);
}
