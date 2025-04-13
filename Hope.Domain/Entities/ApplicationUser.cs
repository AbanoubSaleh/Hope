using Microsoft.AspNetCore.Identity;

namespace Hope.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }=null!;
    public string LastName { get; set; }= null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; } = false;
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}