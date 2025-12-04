using CloudSchool.Transport.Core.Enums;

public record VehicleDto(
    int Id,
    string Name,
    string RegistrationNumber,
    VehicleType VehicleType,
    int SeatCapacity,
    OwnershipType OwnershipType,
    bool IsActive,
    string ModelNameAndNumber,
    int MakeYear,
    string TrackingGpsImei,
    string EngingNumber,
    FuelType FuelType,
    DateOnly RegistrationDate,
    DateOnly CurrentOdometerReading,
    DateOnly NextInspectionDate,
    DateOnly TaskExpiryDate,
    DateOnly TlbExpiryDate,
    DateTime AddedOn,
    string AddedByStaffName,
    DateTime? ModifiedOn,
    string? ModifiedByStaffName
);
