using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    bool Create(T entity);
    List<T> GetAll();
    T? GetById(int id);
    bool Update(T entity);
    bool Delete(int id);
}
