using CarAssignment.Domain.Contracts;

using LiteDB;

namespace CarAssignment.Infrastructure.Interfaces.Persistence;

public interface ILiteDbContext<T> where T : IEntity
{
    string CollectionName { get; }
    LiteDatabase GetDatabase();
}

