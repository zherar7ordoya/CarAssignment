using Integrador.Application.Authorization;

namespace Integrador.Application.Authentication;

public static class Session
{
    public static User? CurrentUser { get; private set; }

    public static void Start(User user)
    {
        CurrentUser = user;
    }

    public static void End()
    {
        CurrentUser = null;
    }

    public static bool IsAuthenticated => CurrentUser != null;
}
