using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.Comments.Commands.DeleteReply
{
    public class DeleteReplyCommand : IRequest<Result<bool>>
    {
        public Guid ReplyId { get; set; }
    }
}