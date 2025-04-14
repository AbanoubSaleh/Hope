namespace Hope.Domain.Entities;

public class Government 
{
    public int Id { get; set; }
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    public string PhoneCode { get; set; } = null!;
    
    // Navigation property for users from this government
    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}