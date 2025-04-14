namespace Hope.Domain.Entities;
using System.Collections.Generic;

public class Government 
{
    public int Id { get; set; }
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    public string PhoneCode { get; set; } = null!;
    
    // Navigation property for users from this government
    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    
    // Navigation property for centers in this government
    public ICollection<Center> Centers { get; set; } = new List<Center>();
}