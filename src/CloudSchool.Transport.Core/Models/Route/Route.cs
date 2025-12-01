namespace CloudSchool.Transport.Core.Models;

public class Route : BaseModel
{
    public string Name { get; set; };
    public string RouteDescription { get; set; };
    public TripType TripType { get; set; }
    
    public int VehicleId { get; set; };
    public int DriverId { get; set; };
    public int MinderId { get; set; }; 
    // many to many
    public ICollection<Station> Stations { get; set; } = new List<Station>();
    public ICollection<Trip> Trips { get; set; } = new List<Trip>()
}
