namespace CarAssignment.Application.DTOs;

public record AssignedCarDTO(string Brand,
                             int Year,
                             string Model,
                             string LicensePlate,
                             string IdentityNumber,
                             string Person);
