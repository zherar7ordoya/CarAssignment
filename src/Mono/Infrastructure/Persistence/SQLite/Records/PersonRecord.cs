namespace Integrador.Infrastructure.Persistence.SQLite.Records;

public class PersonRecord
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string DNI { get; set; } = "";
}
