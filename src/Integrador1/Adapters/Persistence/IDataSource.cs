using Integrador.Entities;

namespace Integrador.Adapters.Persistence;

public interface IDataSource<T> where T : IPersistentEntity
{
    List<T> Read();
    bool Write(List<T> datos);
}