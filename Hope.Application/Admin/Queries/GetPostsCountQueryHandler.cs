using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetPostsCountQueryHandler : IRequestHandler<GetPostsCountQuery, Result<int>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetPostsCountQueryHandler> _logger;

        public GetPostsCountQueryHandler(
            IAdminService adminService,
            ILogger<GetPostsCountQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(GetPostsCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetPostsCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting posts count");
                return Result<int>.Failure("Error getting posts count: " + ex.Message);
            }
        }
    }
}