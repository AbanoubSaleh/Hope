using Hope.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hope.Application.Comments.DTOs
{
    public class ReplyDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public Guid CommentId { get; set; }
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        
        public Guid? ParentReplyId { get; set; }
        public List<ReplyDto> ChildReplies { get; set; } = new List<ReplyDto>();
        
        public static ReplyDto FromEntity(Reply reply)
        {
            return new ReplyDto
            {
                Id = reply.Id,
                Content = reply.Content,
                CreatedAt = reply.CreatedAt,
                UpdatedAt = reply.UpdatedAt,
                CommentId = reply.CommentId,
                UserId = reply.UserId,
                UserName = reply.User?.UserName ?? "Unknown User",
                ParentReplyId = reply.ParentReplyId,
                ChildReplies = reply.ChildReplies
                    .Where(r => !r.IsDeleted)
                    .Select(FromEntity)
                    .ToList()
            };
        }
    }
}