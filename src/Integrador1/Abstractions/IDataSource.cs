namespace Integrador.Abstractions;

public interface IDataSource<T> where T : IEntity
{
    List<T> Read();
    bool Write(List<T> datos);
}