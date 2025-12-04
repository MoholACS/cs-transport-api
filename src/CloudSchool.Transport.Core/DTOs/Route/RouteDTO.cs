using CloudSchool.Transport.Core.Enums;
using CloudSchool.Transport.Core.Models.Station.Dtos;
using CloudSchool.Transport.Core.Models.Trip.Dtos;

public record RouteDto(
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
