using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<Result<Guid>>
    {
        public string Content { get; set; } = null!;
        public Guid ReportId { get; set; }
    }
}