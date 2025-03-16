namespace Integrador.Abstract;

public interface IPersister<T> where T : IEntity
{
    List<T> Read();
    bool Write(List<T> datos);
}