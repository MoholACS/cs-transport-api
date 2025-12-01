namespace CloudSchool.Transport.Core.Enums;

public enum TripStatus
{
    [Display(Name = "Scheduled")]
    Scheduled = 1,

    [Display(Name = "On Going")]
    Ongoing = 2,

    [Display(Name = "Completed")]
    Completed = 3,

    [Display(Name = "Parked")]
    Parked = 4,
}
