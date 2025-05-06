using CarAssignment.Domain.Contracts;

namespace CarAssignment.Infrastructure.Interfaces.Persistence;

public interface IRepository<T> where T : IEntity
{
    void Create(T entity);
    IEnumerable<T> ReadAll();
    T? ReadById(int id);
    void Update(T entity);
    void Delete(int id);
}
