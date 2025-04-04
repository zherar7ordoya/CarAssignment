using Integrador.Domain.Entities;

namespace Integrador.Application.Interfaces;

public interface IDataSource<T> where T : IEntity
{
    List<T> Read();
    bool Write(List<T> data);
}