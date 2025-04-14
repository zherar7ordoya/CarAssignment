namespace Integrador.Infrastructure.Interfaces.Persistence;

public interface IMapper<TDomain, TStorage>
{
    TStorage ToStorage(TDomain entity);
    TDomain ToDomain(TStorage storage);
}

