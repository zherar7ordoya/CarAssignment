using System.Xml.Serialization;

namespace Integrador.Entities;

public abstract class PersistentEntity : IPersistentEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
