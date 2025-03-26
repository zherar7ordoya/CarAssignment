using Integrador.Abstractions;

using System.Xml.Serialization;

namespace Integrador.Adapters.Persistence;

public abstract class BaseEntity : IEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
