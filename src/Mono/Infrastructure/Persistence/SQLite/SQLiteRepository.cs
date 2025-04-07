using System.Data;
using System.Data.SQLite;

using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Infrastructure.Persistence.SQLite.Mappers;
using Integrador.Infrastructure.Persistence.SQLite.Records;

namespace Integrador.Infrastructure.Persistence.SQLite;

public class SQLiteRepository<T, TRecord> : IRepository<T>
    where T : class, IEntity
    where TRecord : class, IRecord
{
    private readonly SQLiteDataSource<T> dataSource;
    private readonly IMapper<T, TRecord> mapper;

    public SQLiteRepository(SQLiteDataSource<T> dataSource, IMapper<T, TRecord> mapper)
    {
        this.dataSource = dataSource;
        this.mapper = mapper;
    }

    public void Create(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
