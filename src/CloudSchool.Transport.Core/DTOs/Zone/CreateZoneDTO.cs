using System.ComponentModel.DataAnnotations;

public record CreateZoneDto(
    [Required] string Name,
    string Description,
    [Range(0, 1000000)] decimal OneWayAmount,
    [Range(0, 1000000)] decimal TwoWayAmount,
    [Range(0, 1000000)] decimal ReturnTripAmount,
    [Required] int CampusId,
    [Required] int CompanyId
);
