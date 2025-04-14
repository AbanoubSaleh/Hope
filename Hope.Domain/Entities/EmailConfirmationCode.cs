using System;

namespace Hope.Domain.Entities
{
    public class EmailConfirmationCode
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Token { get; set; } = null!;
        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; }
        
        // Navigation property
        public virtual ApplicationUser User { get; set; } = null!;
    }
}