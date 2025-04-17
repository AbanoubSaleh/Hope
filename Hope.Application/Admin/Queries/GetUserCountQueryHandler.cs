using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetUserCountQueryHandler : IRequestHandler<GetUserCountQuery, Result<int>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetUserCountQueryHandler> _logger;

        public GetUserCountQueryHandler(
            IAdminService adminService,
            ILogger<GetUserCountQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetUserCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user count");
                return Result<int>.Failure("Error getting user count: " + ex.Message);
            }
        }
    }
}