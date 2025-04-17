using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetAdminsCountQueryHandler : IRequestHandler<GetAdminsCountQuery, Result<int>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAdminsCountQueryHandler> _logger;

        public GetAdminsCountQueryHandler(
            IAdminService adminService,
            ILogger<GetAdminsCountQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<int>> Handle(GetAdminsCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetAdminsCountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting admins count");
                return Result<int>.Failure("Error getting admins count: " + ex.Message);
            }
        }
    }
}