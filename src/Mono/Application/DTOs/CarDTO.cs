namespace Integrador.Application.DTOs;

public record CarDTO(int Id,
                     string Patente,
                     string Marca,
                     string Modelo,
                     int Año,
                     decimal Precio,
                     int DueñoId);
