namespace CloudSchool.Transport.Core.Model;

public class Zone : BaseModel 
{
    public string Name { get; set; };
    public string Description { get; set; };
    public string OneWayAmount { get; set; };
    public string ReturnTripAmmount { get; set; };
}
