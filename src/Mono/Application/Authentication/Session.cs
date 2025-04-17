using Integrador.Application.Authorization;

namespace Integrador.Application.Authentication;

public static class Session
{
    public static User? LoggedUser { get; private set; }

    public static void Start(User user)
    {
        LoggedUser = user;
    }

    public static void End()
    {
        LoggedUser = null;
    }

    public static bool IsLoggedIn => LoggedUser != null;
}
