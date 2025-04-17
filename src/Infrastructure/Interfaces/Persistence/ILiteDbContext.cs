using Integrador.Domain.Contracts;

using LiteDB;

namespace Integrador.Infrastructure.Interfaces.Persistence;

public interface ILiteDbContext<T> where T : IEntity
{
    string CollectionName { get; }
    LiteDatabase GetDatabase();
}

