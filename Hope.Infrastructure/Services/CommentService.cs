using Hope.Application.Comments.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CommentService> _logger;

        public CommentService(ApplicationDbContext context, ILogger<CommentService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Guid>> CreateCommentAsync(string content, Guid reportId, string userId)
        {
            try
            {
                // Check if report exists
                var reportExists = await _context.Reports
                    .AnyAsync(r => r.Id == reportId && !r.IsDeleted);
                
                if (!reportExists)
                {
                    return Result<Guid>.Failure("Report not found or has been deleted");
                }
                
                // Create comment using domain factory method
                var comment = Comment.Create(content, reportId, userId);
                
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Created comment with ID: {CommentId} for report: {ReportId}", comment.Id, reportId);
                return Result<Guid>.Success(comment.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating comment for report {ReportId}", reportId);
                return Result<Guid>.Failure("Error creating comment: " + ex.Message);
            }
        }

        public async Task<Result<Guid>> CreateReplyAsync(string content, Guid commentId, string userId, Guid? parentReplyId = null)
        {
            try
            {
                // Check if comment exists
                var commentExists = await _context.Comments
                    .AnyAsync(c => c.Id == commentId && !c.IsDeleted);
                
                if (!commentExists)
                {
                    return Result<Guid>.Failure("Comment not found or has been deleted");
                }
                
                // If parent reply is specified, check if it exists
                if (parentReplyId.HasValue)
                {
                    var parentReplyExists = await _context.Replies
                        .AnyAsync(r => r.Id == parentReplyId.Value && r.CommentId == commentId && !r.IsDeleted);
                    
                    if (!parentReplyExists)
                    {
                        return Result<Guid>.Failure("Parent reply not found or has been deleted");
                    }
                }
                
                // Create reply using domain factory method
                var reply = Reply.Create(content, commentId, userId, parentReplyId);
                
                _context.Replies.Add(reply);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Created reply with ID: {ReplyId} for comment: {CommentId}", reply.Id, commentId);
                return Result<Guid>.Success(reply.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating reply for comment {CommentId}", commentId);
                return Result<Guid>.Failure("Error creating reply: " + ex.Message);
            }
        }

        public async Task<Result<IEnumerable<CommentDto>>> GetCommentsByReportIdAsync(Guid reportId)
        {
            try
            {
                // Check if report exists
                var reportExists = await _context.Reports
                    .AnyAsync(r => r.Id == reportId && !r.IsDeleted);
                
                if (!reportExists)
                {
                    return Result<IEnumerable<CommentDto>>.Failure("Report not found or has been deleted");
                }
                
                // Get comments with replies
                var comments = await _context.Comments
                    .Include(c => c.User)
                    .Include(c => c.Replies)
                        .ThenInclude(r => r.User)
                    .Include(c => c.Replies)
                        .ThenInclude(r => r.ChildReplies)
                            .ThenInclude(cr => cr.User)
                    .Where(c => c.ReportId == reportId && !c.IsDeleted)
                    .OrderByDescending(c => c.CreatedAt)
                    .ToListAsync();
                
                var commentDtos = comments.Select(CommentDto.FromEntity).ToList();
                
                return Result<IEnumerable<CommentDto>>.Success(commentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving comments for report {ReportId}", reportId);
                return Result<IEnumerable<CommentDto>>.Failure("Error retrieving comments: " + ex.Message);
            }
        }

        public async Task<Result<bool>> UpdateCommentAsync(Guid commentId, string content, string userId)
        {
            try
            {
                var comment = await _context.Comments
                    .FirstOrDefaultAsync(c => c.Id == commentId && !c.IsDeleted);
                
                if (comment == null)
                {
                    return Result<bool>.Failure("Comment not found or has been deleted");
                }
                
                // Check if the user is the owner of the comment
                if (comment.UserId != userId)
                {
                    return Result<bool>.Failure("You can only update your own comments");
                }
                
                comment.UpdateContent(content);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Updated comment with ID: {CommentId}", commentId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment {CommentId}", commentId);
                return Result<bool>.Failure("Error updating comment: " + ex.Message);
            }
        }

        public async Task<Result<bool>> UpdateReplyAsync(Guid replyId, string content, string userId)
        {
            try
            {
                var reply = await _context.Replies
                    .FirstOrDefaultAsync(r => r.Id == replyId && !r.IsDeleted);
                
                if (reply == null)
                {
                    return Result<bool>.Failure("Reply not found or has been deleted");
                }
                
                // Check if the user is the owner of the reply
                if (reply.UserId != userId)
                {
                    return Result<bool>.Failure("You can only update your own replies");
                }
                
                reply.UpdateContent(content);
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Updated reply with ID: {ReplyId}", replyId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating reply {ReplyId}", replyId);
                return Result<bool>.Failure("Error updating reply: " + ex.Message);
            }
        }

        public async Task<Result<bool>> DeleteCommentAsync(Guid commentId, string userId)
        {
            try
            {
                var comment = await _context.Comments
                    .FirstOrDefaultAsync(c => c.Id == commentId && !c.IsDeleted);
                
                if (comment == null)
                {
                    return Result<bool>.Failure("Comment not found or has been deleted");
                }
                
                // Check if the user is the owner of the comment
                if (comment.UserId != userId)
                {
                    return Result<bool>.Failure("You can only delete your own comments");
                }
                
                comment.Delete();
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Deleted comment with ID: {CommentId}", commentId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting comment {CommentId}", commentId);
                return Result<bool>.Failure("Error deleting comment: " + ex.Message);
            }
        }

        public async Task<Result<bool>> DeleteReplyAsync(Guid replyId, string userId)
        {
            try
            {
                var reply = await _context.Replies
                    .FirstOrDefaultAsync(r => r.Id == replyId && !r.IsDeleted);
                
                if (reply == null)
                {
                    return Result<bool>.Failure("Reply not found or has been deleted");
                }
                
                // Check if the user is the owner of the reply
                if (reply.UserId != userId)
                {
                    return Result<bool>.Failure("You can only delete your own replies");
                }
                
                reply.Delete();
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Deleted reply with ID: {ReplyId}", replyId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting reply {ReplyId}", replyId);
                return Result<bool>.Failure("Error deleting reply: " + ex.Message);
            }
        }
    }
}