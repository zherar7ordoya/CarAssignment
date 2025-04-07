using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Interfaces;

public interface IEntityMapper<TDomain, TStorage>
{
    TStorage ToStorage(TDomain entity);
    TDomain ToDomain(TStorage storage);
}

