namespace Integrador.Application.DTOs;

public record PersonDTO(int Id,
                        string DNI,
                        string Nombre,
                        string Apellido,
                        List<CarDTO> Autos);
