using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<Result<bool>>
    {
        public Guid CommentId { get; set; }
    }
}