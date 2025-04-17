using System;
using System.Collections.Generic;

namespace Hope.Domain.Entities
{
    public class Comment
    {
        private Comment() { }
        
        public Guid Id { get; private set; }
        public string Content { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        
        // Foreign keys
        public Guid ReportId { get; private set; }
        public string UserId { get; private set; } = null!;
        
        // Navigation properties
        public Report Report { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public ICollection<Reply> Replies { get; private set; } = new List<Reply>();
        
        public static Comment Create(string content, Guid reportId, string userId)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Comment content cannot be empty", nameof(content));
                
            if (reportId == Guid.Empty)
                throw new ArgumentException("Report ID cannot be empty", nameof(reportId));
                
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be empty", nameof(userId));
                
            return new Comment
            {
                Id = Guid.NewGuid(),
                Content = content,
                ReportId = reportId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow
            };
        }
        
        public void UpdateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Comment content cannot be empty", nameof(content));
                
            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }
        
        public void Delete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
    }
}