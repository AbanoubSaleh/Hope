using Hope.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hope.Application.Comments.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public Guid ReportId { get; set; }
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        
        public List<ReplyDto> Replies { get; set; } = new List<ReplyDto>();
        
        public static CommentDto FromEntity(Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt,
                ReportId = comment.ReportId,
                UserId = comment.UserId,
                UserName = comment.User?.UserName ?? "Unknown User",
                Replies = comment.Replies
                    .Where(r => !r.IsDeleted && r.ParentReplyId == null)
                    .Select(ReplyDto.FromEntity)
                    .ToList()
            };
        }
    }
}