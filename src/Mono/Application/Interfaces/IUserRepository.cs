using Integrador.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Interfaces;

public interface IUserRepository
{
    User? GetByUsername(string username);
    List<User> GetAll();
}
