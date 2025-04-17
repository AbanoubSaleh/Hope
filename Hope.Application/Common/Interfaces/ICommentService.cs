using Hope.Application.Comments.DTOs;
using Hope.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface ICommentService
    {
        Task<Result<Guid>> CreateCommentAsync(string content, Guid reportId, string userId);
        Task<Result<Guid>> CreateReplyAsync(string content, Guid commentId, string userId, Guid? parentReplyId = null);
        Task<Result<IEnumerable<CommentDto>>> GetCommentsByReportIdAsync(Guid reportId);
        Task<Result<bool>> UpdateCommentAsync(Guid commentId, string content, string userId);
        Task<Result<bool>> UpdateReplyAsync(Guid replyId, string content, string userId);
        Task<Result<bool>> DeleteCommentAsync(Guid commentId, string userId);
        Task<Result<bool>> DeleteReplyAsync(Guid replyId, string userId);
    }
}