namespace CloudSchool.Transport.Core.Model;

public class Station : BaseModel 
{
    public string StationName { get; set; };
    public string? Geolocation { get; set; };
    public string? Description { get; set; };
    public string? Landmark { get; set; };

    // Foreign Keys
    public int RouteId { get; set; };
    
    // Navigation property 
    public Route? Route { get; set; };
}
