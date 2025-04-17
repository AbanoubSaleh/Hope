using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetDeletedPostsCountQueryHandler : IRequestHandler<GetDeletedPostsCountQuery, Result<int>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetDeletedPostsCountQueryHandler> _logger;

        public GetDeletedPostsCountQueryHandler(
            IAdminService adminService,
            ILogger<GetDeletedPostsCountQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(GetDeletedPostsCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetDeletedPostsCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting deleted posts count");
                return Result<int>.Failure("Error getting deleted posts count: " + ex.Message);
            }
        }
    }
}