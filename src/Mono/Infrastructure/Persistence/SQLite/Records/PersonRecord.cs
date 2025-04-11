namespace Integrador.Infrastructure.Persistence.SQLite.Records;

public class PersonRecord
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public string CarIds { get; set; } = string.Empty;
}
