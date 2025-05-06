namespace CarAssignment.Infrastructure.Persistence.SQLite.Records;

public class CarRecord
{
    public int Id { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public decimal Price { get; set; } = 0;
    public int? PersonId { get; set; }
}
