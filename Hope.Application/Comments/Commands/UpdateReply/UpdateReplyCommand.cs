using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.Comments.Commands.UpdateReply
{
    public class UpdateReplyCommand : IRequest<Result<bool>>
    {
        public Guid ReplyId { get; set; }
        public string Content { get; set; } = null!;
    }
}