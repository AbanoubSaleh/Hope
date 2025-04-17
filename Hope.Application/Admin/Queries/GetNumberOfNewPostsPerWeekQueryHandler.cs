using Hope.Application.Admin.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetNumberOfNewPostsPerWeekQueryHandler : IRequestHandler<GetNumberOfNewPostsPerWeekQuery, Result<List<WeeklyCountDto>>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetNumberOfNewPostsPerWeekQueryHandler> _logger;

        public GetNumberOfNewPostsPerWeekQueryHandler(
            IAdminService adminService,
            ILogger<GetNumberOfNewPostsPerWeekQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<List<WeeklyCountDto>>> Handle(GetNumberOfNewPostsPerWeekQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetNumberOfNewPostsPerWeekAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting weekly post counts");
                return Result<List<WeeklyCountDto>>.Failure("Error getting weekly post counts: " + ex.Message);
            }
        }
    }
}