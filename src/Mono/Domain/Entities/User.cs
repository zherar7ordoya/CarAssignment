using Integrador.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Domain.Entities;

public class User : EntityBase
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public Role Role { get; set; }
}
