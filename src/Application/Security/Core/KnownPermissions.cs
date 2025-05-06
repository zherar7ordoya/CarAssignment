namespace CarAssignment.Application.Security.Core;

public static class KnownPermissions
{
    public static readonly Permission NewPerson      = new("NewPerson");
    public static readonly Permission SavePerson     = new("SavePerson");
    public static readonly Permission DeletePerson   = new("DeletePerson");

    public static readonly Permission NewCar         = new("NewCar");
    public static readonly Permission SaveCar        = new("SaveCar");
    public static readonly Permission DeleteCar      = new("DeleteCar");

    public static readonly Permission AssignCar      = new("AssignCar");
    public static readonly Permission RemoveCar      = new("RemoveCar");

    public static readonly Permission LogViewer      = new("LogViewer");
    public static readonly Permission UserManagement = new("UserManagement");
    public static readonly Permission RoleManagement = new("RoleManagement");

    public static IEnumerable<Permission> All =>
    [
        NewPerson, SavePerson, DeletePerson, 
        NewCar, SaveCar, DeleteCar,
        AssignCar, RemoveCar,
        LogViewer, UserManagement, RoleManagement
    ];
}

