using Hope.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

            try
            {
                // Ensure roles exist
                string[] roles = { "SuperAdmin", "Admin", "User" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                        logger.LogInformation("Created role {Role}", role);
                    }
                }

                // Check if SuperAdmin exists
                var superAdminEmail = configuration["SuperAdmin:Email"] ?? "theabanoubsaleh@gmail.com";
                var superAdminUsername = superAdminEmail; // Use email as username for consistency
                var superAdminPassword = configuration["SuperAdmin:Password"] ?? "SuperAdmin123!";
                
                logger.LogInformation("Attempting to find or create SuperAdmin with email: {Email}", superAdminEmail);
                
                var superAdmin = await userManager.FindByEmailAsync(superAdminEmail);

                if (superAdmin == null)
                {
                    // Create SuperAdmin with current date
                    superAdmin = new ApplicationUser
                    {
                        UserName = superAdminUsername,
                        Email = superAdminEmail,
                        EmailConfirmed = true,
                        CreatedAt = DateTime.UtcNow,
                        FirstName = "Super",
                        LastName = "Admin",
                        GovernmentId = 1
                    };

                    logger.LogInformation("Creating new SuperAdmin user with UserName={Username}, Email={Email}", 
                        superAdmin.UserName, superAdmin.Email);
                    
                    var result = await userManager.CreateAsync(superAdmin, superAdminPassword);

                    if (result.Succeeded)
                    {
                        // Explicitly add to SuperAdmin role
                        await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                        logger.LogInformation("Created SuperAdmin user with email {Email}", superAdminEmail);
                        
                        // Verify role assignment
                        var adminRoles = await userManager.GetRolesAsync(superAdmin);
                        logger.LogInformation("SuperAdmin roles: {Roles}", string.Join(", ", adminRoles));
                    }
                    else
                    {
                        logger.LogError("Failed to create SuperAdmin user: {Errors}", 
                            string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }
                else
                {
                    logger.LogInformation("SuperAdmin user already exists with ID={Id}, UserName={Username}, Email={Email}", 
                        superAdmin.Id, superAdmin.UserName, superAdmin.Email);
                    
                    // Update username if it doesn't match email (for consistency)
                    if (superAdmin.UserName != superAdminEmail)
                    {
                        superAdmin.UserName = superAdminEmail;
                        await userManager.UpdateAsync(superAdmin);
                        logger.LogInformation("Updated SuperAdmin username to match email: {Email}", superAdminEmail);
                    }
                    
                    // Always reset the password for existing SuperAdmin to ensure it works
                    var resetToken = await userManager.GeneratePasswordResetTokenAsync(superAdmin);
                    var resetResult = await userManager.ResetPasswordAsync(superAdmin, resetToken, superAdminPassword);
                    
                    if (resetResult.Succeeded)
                    {
                        logger.LogInformation("Reset password for SuperAdmin user");
                    }
                    else
                    {
                        logger.LogError("Failed to reset SuperAdmin password: {Errors}", 
                            string.Join(", ", resetResult.Errors.Select(e => e.Description)));
                    }
                    
                    // Ensure user has SuperAdmin role
                    if (!await userManager.IsInRoleAsync(superAdmin, "SuperAdmin"))
                    {
                        await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                        logger.LogInformation("Added SuperAdmin role to existing user with email {Email}", superAdminEmail);
                    }
                    
                    // Fix the CreatedAt date if it's in the future
                    if (superAdmin.CreatedAt > DateTime.UtcNow)
                    {
                        superAdmin.CreatedAt = DateTime.UtcNow;
                        await userManager.UpdateAsync(superAdmin);
                        logger.LogInformation("Fixed future CreatedAt date for SuperAdmin");
                    }
                    
                    // Ensure email is confirmed
                    if (!superAdmin.EmailConfirmed)
                    {
                        superAdmin.EmailConfirmed = true;
                        await userManager.UpdateAsync(superAdmin);
                        logger.LogInformation("Set EmailConfirmed to true for SuperAdmin");
                    }
                }
                
                // Force save changes to ensure everything is persisted
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while seeding default users and roles: {Message}", ex.Message);
            }
        }
    }
}


