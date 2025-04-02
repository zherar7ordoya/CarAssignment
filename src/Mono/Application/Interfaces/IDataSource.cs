namespace Integrador.Application.Interfaces;

public interface IDataSource<T> where T : IEntity
{
    Task<List<T>> ReadAsync(CancellationToken ct);
    Task<bool> WriteAsync(List<T> data, CancellationToken ct);
}