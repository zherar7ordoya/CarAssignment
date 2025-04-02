namespace Integrador.Application.Interfaces;

public interface IGenericRepository<T> where T : IEntity
{
    Task<bool> CreateAsync(T entity, CancellationToken ct = default);
    Task<List<T>> GetAllAsync(CancellationToken ct = default);
    Task<T?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<bool> UpdateAsync(T entity, CancellationToken ct = default);
    Task<bool> DeleteAsync(T entity, CancellationToken ct = default);
}
