namespace CloudSchool.Transport.Core.Model;

public class Staff : BaseModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string OtherName { get; set; };
    public string Email { get; set; } = string.Empty;

    public RoleGroup RoleGroup { get; set; }
    public StaffStatus StaffStatus { get; set; };
    
    // Password storage as the stafff is also the users 
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

    // For Possible JWT
    public string? RefreshToken { get; set; };
    public DateTime? RefreshTokenExpiryTime { get; set; };

}