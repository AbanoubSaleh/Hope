using System;

namespace Hope.Domain.Entities
{
    public class Reply
    {
        private Reply() { }
        
        public Guid Id { get; private set; }
        public string Content { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        
        // Foreign keys
        public Guid CommentId { get; private set; }
        public string UserId { get; private set; } = null!;
        public Guid? ParentReplyId { get; private set; }
        
        // Navigation properties
        public Comment Comment { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public Reply? ParentReply { get; private set; }
        public ICollection<Reply> ChildReplies { get; private set; } = new List<Reply>();
        
        public static Reply Create(string content, Guid commentId, string userId, Guid? parentReplyId = null)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Reply content cannot be empty", nameof(content));
                
            if (commentId == Guid.Empty)
                throw new ArgumentException("Comment ID cannot be empty", nameof(commentId));
                
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be empty", nameof(userId));
                
            return new Reply
            {
                Id = Guid.NewGuid(),
                Content = content,
                CommentId = commentId,
                UserId = userId,
                ParentReplyId = parentReplyId,
                CreatedAt = DateTime.UtcNow
            };
        }
        
        public void UpdateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Reply content cannot be empty", nameof(content));
                
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