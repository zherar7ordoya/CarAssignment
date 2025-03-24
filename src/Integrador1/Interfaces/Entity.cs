using System.Xml.Serialization;

namespace Integrador.Interfaces;

public abstract class Entity : IEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
