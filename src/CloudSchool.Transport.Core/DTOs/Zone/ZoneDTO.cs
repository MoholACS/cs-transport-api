public record ZoneDto(
    int Id,
    string Name,
    string Description,
    decimal OneWayAmount,
    decimal TwoWayAmount,
    decimal ReturnTripAmount,
    int CampusId,
    int CompanyId,
    DateTime AddedOn,
    string AddedByStaffName,
    DateTime? ModifiedOn,
    string? ModifiedByStaffName
);
