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
    public class GetNumberOfNewUserPerWeekQueryHandler : IRequestHandler<GetNumberOfNewUserPerWeekQuery, Result<List<WeeklyCountDto>>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetNumberOfNewUserPerWeekQueryHandler> _logger;

        public GetNumberOfNewUserPerWeekQueryHandler(
            IAdminService adminService,
            ILogger<GetNumberOfNewUserPerWeekQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<List<WeeklyCountDto>>> Handle(GetNumberOfNewUserPerWeekQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetNumberOfNewUsersPerWeekAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting weekly new user counts");
                return Result<List<WeeklyCountDto>>.Failure("Error getting weekly new user counts: " + ex.Message);
            }
        }
    }
}