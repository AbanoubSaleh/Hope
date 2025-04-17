using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Admin.Commands
{
    public class AdminRegisterCommandHandler : IRequestHandler<AdminRegisterCommand, Result<string>>
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminRegisterCommandHandler> _logger;

        public AdminRegisterCommandHandler(
            IAdminService adminService,
            ILogger<AdminRegisterCommandHandler> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public async Task<Result<string>> Handle(AdminRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _adminService.AdminRegisterAsync(
                    request.UserName,
                    request.Email,
                    request.Password,
                    request.IsAdmin);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering admin user");
                return Result<string>.Failure("Error registering admin user: " + ex.Message);
            }
        }
    }
}