using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Result<Guid>>
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateCommentCommandHandler(
            ICommentService commentService,
            IHttpContextAccessor httpContextAccessor)
        {
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<Guid>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (string.IsNullOrEmpty(userId))
            {
                return Result<Guid>.Failure("User not authenticated");
            }
            
            return await _commentService.CreateCommentAsync(request.Content, request.ReportId, userId);
        }
    }
}