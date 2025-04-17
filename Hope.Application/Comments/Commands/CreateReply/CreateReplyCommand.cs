using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.Comments.Commands.CreateReply
{
    public class CreateReplyCommand : IRequest<Result<Guid>>
    {
        public string Content { get; set; } = null!;
        public Guid CommentId { get; set; }
        public Guid? ParentReplyId { get; set; }
    }
}