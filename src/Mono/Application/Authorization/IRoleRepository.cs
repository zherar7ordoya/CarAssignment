using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public interface IRoleRepository
{
    Role? GetByName(string name);
    List<Role> GetAll();
    void Save(Role role);
    void Delete(string name);
}

