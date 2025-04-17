using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Users.Commands.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, Result<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AssignRoleCommandHandler> _logger;

        public AssignRoleCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AssignRoleCommandHandler> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<Result<bool>> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if the user exists
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                {
                    return Result<bool>.Failure("User not found");
                }

                // Check if the role exists
                var roleExists = await _roleManager.RoleExistsAsync(request.RoleName);
                if (!roleExists)
                {
                    return Result<bool>.Failure($"Role '{request.RoleName}' does not exist");
                }

                // Check if the user is already in the role
                var isInRole = await _userManager.IsInRoleAsync(user, request.RoleName);
                if (isInRole)
                {
                    return Result<bool>.Success(true); // User is already in the role
                }

                // Add the user to the role
                var result = await _userManager.AddToRoleAsync(user, request.RoleName);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to assign role {RoleName} to user {UserId}", request.RoleName, request.UserId);
                    return Result<bool>.Failure("Failed to assign role: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                _logger.LogInformation("Assigned role {RoleName} to user {UserId}", request.RoleName, request.UserId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning role {RoleName} to user {UserId}", request.RoleName, request.UserId);
                return Result<bool>.Failure("Error assigning role: " + ex.Message);
            }
        }
    }
}