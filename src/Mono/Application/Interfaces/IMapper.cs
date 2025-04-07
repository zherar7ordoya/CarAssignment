namespace Integrador.Application.Interfaces;

public interface IMapper<TDomain, TStorage>
{
    TStorage ToStorage(TDomain entity);
    TDomain ToDomain(TStorage storage);
}

