using Integrador.Domain.Interfaces;

namespace Integrador.Application.Interfaces.Persistence;

public interface IXmlContext<T> where T : IEntity
{
    List<T> Read();
    void Write(List<T> data);
}