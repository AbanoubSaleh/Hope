using Hope.Application.Comments.DTOs;
using Hope.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Hope.Application.Comments.Queries.GetCommentsByReportId
{
    public class GetCommentsByReportIdQuery : IRequest<Result<IEnumerable<CommentDto>>>
    {
        public Guid ReportId { get; set; }
    }
}