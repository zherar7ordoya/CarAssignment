using Integrador.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Authorization;

public interface IUserRepository
{
    User? GetByUsername(string username);
    List<User> GetAll();
    void Save(User user);
    void Delete(string username);
    void Update(User user);
}

