namespace Integrador.Application.Interfaces;

public interface IXmlDataSource<T> where T : Domain.Entities.IEntity
{
    List<T> Read();
    void Write(List<T> data);
}