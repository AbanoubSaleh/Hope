using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetPostThingsQueryHandler : IRequestHandler<GetPostThingsQuery, Result<IEnumerable<ReportDto>>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetPostThingsQueryHandler> _logger;

        public GetPostThingsQueryHandler(
            IAdminService adminService,
            ILogger<GetPostThingsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ReportDto>>> Handle(GetPostThingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetPostThingsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving post things");
                return Result<IEnumerable<ReportDto>>.Failure($"Error retrieving post things: {ex.Message}");
            }
        }
    }
}