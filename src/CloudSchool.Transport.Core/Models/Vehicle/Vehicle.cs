using CloudSchool.Transport.Core.Enums;

namespace CloudSchool.Transport.Core.Models;

public class Vehicle : BaseModel
{
    // General Info 
    public string Name { get; set; };
    public string RegistrationNumber {get; set;};
    public VehicleType VehicleType { get; set; } = VehicleType.Bus;

    public int SeatCapacity { get; set; }
    
    public OwnershipType OwnershipType { get; set; };
    
    public bool IsActive { get; set; } = true;

    // Additional Information 
    public string ModelNameAndNumber { get; set; } = string.Empty;
    public int MakeYear { get; set; };
    public string TrackingGpsImei { get; set; } = string.Empty;
    public string EngingNumber { get; set; };
    public FuelType FuelType { get; set; };
    public DateOnly RegistrationDate { get; set; };
    public DateOnly CurrentOdometerReading { get; set; };
    public DateOnly NextInspectionDate { get; set; };
    public DateOnly TaskExpiryDate { get; set; };
    public DateOnly TlbExpiryDate { get; set; };

    // Navigation Properties
    public ICollection<Route> Routes { get; set; } = new List<Route>();
}