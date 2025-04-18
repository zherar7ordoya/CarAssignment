using Integrador.Domain.Entities;

namespace Integrador.Application.Authentication.State;

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
