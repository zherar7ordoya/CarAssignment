using Integrador.Domain.Interfaces;

using System.Xml.Serialization;

namespace Integrador.Domain.Entities;

public abstract class EntityBase : IEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
