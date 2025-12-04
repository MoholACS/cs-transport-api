namespace CloudSchool.Transport.Core.Model;

public class Trip: BaseModel
{
    public TripType TipType { get; set; };
    public ScheduleType ScheduleType { get; set; }
    
    public DateOnly Date { get; set; };
    public TimeOnly StartTime { get; set; }

    public int RouteId { get; set; };
    public int VehicleId { get; set; };
    public int MinderId { get; set; };
    public int DriverId { get; set; };

    public TripStatus TripStatus {get; set;};
    public string VehicleRegistration { get; set;} = string.Empty;

    // Naviation properties
    public Route? Route { get; set; };
    public Vehicle? Vehicle { get; set; };
    public Staff? Staff { get; set; };
    public Staff? Driver { get; set; };
    public Staff? Minder { get; set; };
}