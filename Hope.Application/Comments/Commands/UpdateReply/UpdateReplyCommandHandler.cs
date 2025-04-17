using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Comments.Commands.UpdateReply
{
    public class UpdateReplyCommandHandler : IRequestHandler<UpdateReplyCommand, Result<bool>>
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateReplyCommandHandler(
            ICommentService commentService,
            IHttpContextAccessor httpContextAccessor)
        {
            _commentService = commentService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<bool>> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (string.IsNullOrEmpty(userId))
            {
                return Result<bool>.Failure("User not authenticated");
            }
            
            return await _commentService.UpdateReplyAsync(request.ReplyId, request.Content, userId);
        }
    }
}