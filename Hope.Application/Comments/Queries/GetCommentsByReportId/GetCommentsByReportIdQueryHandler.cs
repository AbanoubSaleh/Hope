using Hope.Application.Comments.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Comments.Queries.GetCommentsByReportId
{
    public class GetCommentsByReportIdQueryHandler : IRequestHandler<GetCommentsByReportIdQuery, Result<IEnumerable<CommentDto>>>
    {
        private readonly ICommentService _commentService;

        public GetCommentsByReportIdQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<Result<IEnumerable<CommentDto>>> Handle(GetCommentsByReportIdQuery request, CancellationToken cancellationToken)
        {
            return await _commentService.GetCommentsByReportIdAsync(request.ReportId);
        }
    }
}