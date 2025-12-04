using System.ComponentModel.DataAnnotations;
using CloudSchool.Transport.Core.Enums;

public record CreateRouteDto(
    [Required] string Name,
    string RouteDescription,
    TripType TripType,
    int VehicleId,
    int DriverId,
    int MinderId,
    IReadOnlyList<CreateStationDto> Stations
);
