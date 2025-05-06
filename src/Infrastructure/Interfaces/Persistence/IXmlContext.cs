using CarAssignment.Domain.Contracts;

namespace CarAssignment.Infrastructure.Interfaces.Persistence;

public interface IXmlContext<T> where T : IEntity
{
    List<T> Read();
    void Write(List<T> data);
}