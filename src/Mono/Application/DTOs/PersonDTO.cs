namespace Integrador.Application.DTOs;

public record PersonDto(int Id,
                        string DNI,
                        string Nombre,
                        string Apellido,
                        List<CarDTO> Autos);
