namespace CloudSchool.Transport.Core.Models;

using CloudSchool.Transport.Core.Models.Staff;
using System.ComponentModel.DataAnnotations;
public abstract class BaseModel 
{
    [Key]
    public int Id { get; set; };
    public DateTime AddedOn {get; set;} = DateTime.UtcNow; 

    // Foreign keys used to the stafF
    public int AddedByStaffId {get; set;};
    public int? ModifiedByStaffId {get; set; };
    public DateTime? ModifiedOn { get; set; };
    public bool isDeleted { get; set; } = false;

    // Navigation Properties
    public Staff AddedByStaff { get; set; };
    public Staff? ModifiedByStaff { get; set; };

}