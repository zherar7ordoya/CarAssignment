namespace Integrador.Infrastructure.Persistence.SQLite.Records;

public class CarRecord
{
    public int Id { get; set; }
    public string Patente { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Año { get; set; } = 0;
    public decimal Precio { get; set; } = 0;
    public int? DueñoId { get; set; }
}
