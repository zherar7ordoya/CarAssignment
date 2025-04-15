using Integrador.Application.Authorization;

namespace Integrador.Application.State;

public static class Session
{
    public static User? CurrentUser { get; set; }
    public static bool IsAuthenticated => CurrentUser is not null;
    public static void Logout() => CurrentUser = null;
}

