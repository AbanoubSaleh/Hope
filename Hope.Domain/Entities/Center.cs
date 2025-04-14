namespace Hope.Domain.Entities;

public class Center
{
    public Guid Id { get; set; }
    
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    
    public int GovernmentId { get; set; }
    public Government Government { get; set; } = null!;
    
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}