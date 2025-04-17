using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest<Result<bool>>
    {
        public Guid CommentId { get; set; }
        public string Content { get; set; } = null!;
    }
}