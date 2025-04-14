using Integrador.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Application.Interfaces;

public interface IAuthService
{
    bool Login(string username, string password);
    User? GetCurrentUser();
}
