namespace Hope.Domain.Entities;

public class Center
{
    public Guid Id { get; set; }
    
    // Replace single Name with NameEn and NameAr
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    
    // Add Government relationship
    public int GovernmentId { get; set; }
    public Government Government { get; set; } = null!;
    
    // Navigation property
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}