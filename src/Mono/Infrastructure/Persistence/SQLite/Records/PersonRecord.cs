namespace Integrador.Infrastructure.Persistence.SQLite.Records;

public class PersonRecord
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string DNI { get; set; } = string.Empty;
    public string Autos { get; set; } = string.Empty;
}
