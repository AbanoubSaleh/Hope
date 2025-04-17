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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<PaginatedList<UserDto>>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;

        public GetAllUsersQueryHandler(
            IAdminService adminService,
            ILogger<GetAllUsersQueryHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<PaginatedList<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.GetAllUsersAsync(request.PageNumber, request.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all users");
                return Result<PaginatedList<UserDto>>.Failure("Error retrieving all users: " + ex.Message);
            }
        }
    }
}