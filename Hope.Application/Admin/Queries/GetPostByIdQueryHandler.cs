using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Result<ReportDto>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetPostByIdQueryHandler> _logger;

        public GetPostByIdQueryHandler(
            IAdminService adminService,
            ILogger<GetPostByIdQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<ReportDto>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetPostByIdAsync(request.ReportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving post with ID {PostId}", request.ReportId);
                return Result<ReportDto>.Failure($"Error retrieving post with ID {request.ReportId}: {ex.Message}");
            }
        }
    }
}