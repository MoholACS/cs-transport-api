using CloudSchool.Transport.Core.Enums;

public record TripDto(
    int Id,
    string Name,
    string RouteDescription,
    TripType TripType,
    string VehicleRegistrationNumber,
    string DriverName,
    string MinderName,
    IReadOnlyList<StationDto> Stations,
    IReadOnlyList<TripDto> Trips,
    DateTime AddedOn,
    string AddedByStaffName,
    DateTime? ModifiedOn,
    string? ModifiedByStaffName
);
