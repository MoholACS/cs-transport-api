namespace CloudSchool.Transport.Core.Enums;

public enum TripType
{
    [Display(Name = " School to Home")]
    SchoolToHome = 1,

    [Display(Name = "Home to School")]
    HomeToSchool = 2,

    [Display(Name = "Round Trip")]
    RoundTrip = 3,

    [Display(Name = "Other")]
    Other = 4,
}
