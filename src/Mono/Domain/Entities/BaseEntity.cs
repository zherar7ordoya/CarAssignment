using Integrador.Application.Interfaces;

using System.Xml.Serialization;

namespace Integrador.Domain.Entities;

public abstract class BaseEntity : IEntity
{
    [XmlAttribute]
    public int Id { get; set; } = 0;
}
