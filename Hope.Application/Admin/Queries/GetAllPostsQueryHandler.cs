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
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, Result<IEnumerable<ReportDto>>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllPostsQueryHandler> _logger;

        public GetAllPostsQueryHandler(
            IAdminService adminService,
            ILogger<GetAllPostsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<ReportDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetAllPostsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all posts");
                return Result<IEnumerable<ReportDto>>.Failure("Error retrieving all posts: " + ex.Message);
            }
        }
    }
}