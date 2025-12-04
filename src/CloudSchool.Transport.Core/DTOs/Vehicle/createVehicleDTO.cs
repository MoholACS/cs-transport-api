using System.ComponentModel.DataAnnotations;
using CloudSchool.Transport.Core.Enums;

public record CreateVehicleDto(
    [Required] string Name,
    [Required] string RegistrationNumber,
    VehicleType VehicleType,
    [Range(1, 100)] int SeatCapacity,
    OwnershipType OwnershipType,
    string ModelNameAndNumber,
    int MakeYear,
    string TrackingGpsImei,
    string EngingNumber,
    FuelType FuelType,
    DateOnly RegistrationDate,
    DateOnly CurrentOdometerReading,
    DateOnly NextInspectionDate,
    DateOnly TaskExpiryDate,
    DateOnly TlbExpiryDate
);
