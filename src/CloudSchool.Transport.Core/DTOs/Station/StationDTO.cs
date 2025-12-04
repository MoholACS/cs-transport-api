public record StationDto(
    int Id,
    string StationName,
    string? Geolocation,
    string? Landmark,
    string? Description,
    int RouteId,
    string RouteName,
    DateTime AddedOn,
    string AddedByStaffName,
    DateTime? ModifiedOn,
    string? ModifiedByStaffName
);
