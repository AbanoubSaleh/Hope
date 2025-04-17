using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Queries
{
    public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, Result<List<UserDto>>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllAdminsQueryHandler> _logger;

        public GetAllAdminsQueryHandler(
            IAdminService adminService,
            ILogger<GetAllAdminsQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<List<UserDto>>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetAllAdminsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all admins");
                return Result<List<UserDto>>.Failure("Error retrieving all admins: " + ex.Message);
            }
        }
    }
}