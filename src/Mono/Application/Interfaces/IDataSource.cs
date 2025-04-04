using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IDataSource<T> where T : IEntity
{
    List<T> Read();
    void Write(List<T> data);
}