using System.Xml.Serialization;

namespace Integrador1.Abstract;

public abstract class Entity : IEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
