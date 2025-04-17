using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Hope.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string? ProfileImageUrl { get; set; }
        
        // Foreign key for Government
        public int? GovernmentId { get; set; }
        
        // Navigation properties
        public Government? Government { get; set; }
        
        // Collection navigation property for Reports
        public ICollection<Report> Reports { get; set; } = new List<Report>();
    }
}