using Integrador.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador.Presentation;

public static class Session
{
    public static User? CurrentUser { get; set; }
    public static bool IsAuthenticated => CurrentUser is not null;
    public static void Logout() => CurrentUser = null;
}

