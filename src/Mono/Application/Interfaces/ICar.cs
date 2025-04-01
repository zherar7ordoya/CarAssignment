namespace Integrador.Application.Interfaces
{
    public interface ICar
    {
        int Id { get; set; }
        int Año { get; set; }
        int DueñoId { get; set; }
        string Marca { get; set; }
        string Modelo { get; set; }
        string Patente { get; set; }
        decimal Precio { get; set; }
    }
}