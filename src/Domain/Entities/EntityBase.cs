using CarAssignment.Domain.Contracts;

using System.Xml.Serialization;

namespace CarAssignment.Domain.Entities;

public abstract class EntityBase : IEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
