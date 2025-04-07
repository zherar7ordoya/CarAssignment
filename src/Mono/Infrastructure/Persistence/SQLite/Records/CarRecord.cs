namespace Integrador.Infrastructure.Persistence.SQLite.Records;

public class CarRecord
{
    public int Id { get; set; }
    public string Patente { get; set; } = "";
    public string Marca { get; set; } = "";
    public string Modelo { get; set; } = "";
    public int Año { get; set; } = 0;
    public decimal Precio { get; set; } = 0;
}
