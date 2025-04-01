using Integrador.Domain.Entities;

namespace Integrador.Shared.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string Apellido { get; set; }
        List<Car> Autos { get; set; }
        string DNI { get; set; }
        string Nombre { get; set; }

        string GetApellidoNombre();
        int GetCantidadAutos();
        string GetDNI();
        List<Car> GetListaAutos();
        decimal GetValorAutos();
    }
}