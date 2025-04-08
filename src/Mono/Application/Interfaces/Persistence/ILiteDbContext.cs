using Integrador.Domain.Interfaces;

using LiteDB;

namespace Integrador.Application.Interfaces.Persistence;

public interface ILiteDbContext<T> where T : IEntity
{
    string CollectionName { get; }
    LiteDatabase GetDatabase();
}

