using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Commands.HideReport
{
    public class UnHideReportCommandHandler : IRequestHandler<UnHideReportCommand, Result<bool>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<UnHideReportCommandHandler> _logger;

        public UnHideReportCommandHandler(
            IAdminService adminService,
            ILogger<UnHideReportCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<bool>> Handle(UnHideReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.UnHideReportAsync(request.ReportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unhiding report {ReportId}", request.ReportId);
                return Result<bool>.Failure("Error unhiding report: " + ex.Message);
            }
        }
    }
}