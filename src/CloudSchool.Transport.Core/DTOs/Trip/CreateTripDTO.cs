using System.ComponentModel.DataAnnotations;
using CloudSchool.Transport.Core.Enums;

public record CreateTripDto(
    [Required] TripType TripType,
    [Required] ScheduleType Schedule,
    DateOnly Date,
    TimeOnly StartTime,
    string? Description,
    int RouteId,
    int VehicleId,
    int DriverId,
    int MinderId,
    [Required] string VehicleRegistration
);
