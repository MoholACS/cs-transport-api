using System.ComponentModel.DataAnnotations;

public record CreateStationDto(
    [Required] string StationName,
    string? Geolocation,
    string? Landmark,
    string? Description,
    [Required] int RouteId
);
