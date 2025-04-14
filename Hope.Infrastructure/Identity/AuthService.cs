using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hope.Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;
        private readonly IEmailService _emailService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ILogger<AuthService> logger,
            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<Result<ApplicationUser>> RegisterUserAsync(string email, string password, string firstName, string lastName,int governmentId,string phoneNumber)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return Result<ApplicationUser>.Failure("User with this email already exists");
            }

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                EmailConfirmed = false,
                GovernmentId= governmentId,
                PhoneNumber= phoneNumber
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.ToDictionary(
                    error => error.Code,
                    error => new[] { error.Description }
                );
                return Result<ApplicationUser>.Failure("Failed to create user", errors);
            }

            _logger.LogInformation("User created a new account with password");
            return Result<ApplicationUser>.Success(user);
        }

        public async Task<Result<ApplicationUser>> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Result<ApplicationUser>.Failure("Invalid login attempt");
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return Result<ApplicationUser>.Failure("Email not confirmed");
            }

            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in");
                return Result<ApplicationUser>.Success(user);
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out");
                return Result<ApplicationUser>.Failure("Account locked out");
            }

            return Result<ApplicationUser>.Failure("Invalid login attempt");
        }

        public async Task<Result> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Result.Failure("User not found");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                var errors = result.Errors.ToDictionary(
                    error => error.Code,
                    error => new[] { error.Description }
                );
                return Result.Failure("Email confirmation failed", errors);
            }

            _logger.LogInformation("User confirmed their email");
            return Result.Success("Email confirmed successfully");
        }

        public async Task<Result> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return Result.Success("If your email is registered, you will receive a password reset link");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = System.Web.HttpUtility.UrlEncode(token);
            var callbackUrl = $"https://yourdomain.com/reset-password?email={email}&token={encodedToken}";

            await _emailService.SendPasswordResetAsync(email, callbackUrl);

            _logger.LogInformation("Password reset email sent to {Email}", email);
            return Result.Success("Password reset email sent");
        }

        public async Task<Result> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return Result.Failure("Password reset failed");
            }

            // Decode the URL-encoded token
            var decodedToken = System.Web.HttpUtility.UrlDecode(token);

            var result = await _userManager.ResetPasswordAsync(user, decodedToken, newPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.ToDictionary(
                    error => error.Code,
                    error => new[] { error.Description }
                );
                return Result.Failure("Password reset failed", errors);
            }

            _logger.LogInformation("Password reset successful for {Email}", email);
            return Result.Success("Password has been reset successfully");
        }

        public async Task<Result<ApplicationUser>> ExternalLoginAsync(string provider, string idToken)
        {
            try
            {
                // This is a simplified version. In a real implementation, you would validate the token
                // with the external provider and extract user information.
                
                // For Google, you would use GoogleJsonWebSignature.ValidateAsync
                // For Facebook, you would use the Facebook Graph API
                
                // For this example, let's assume we've validated the token and extracted the email
                string email = "extracted-from-token@example.com"; // This would come from token validation
                string firstName = "External";
                string lastName = "User";
                
                var user = await _userManager.FindByEmailAsync(email);
                
                if (user == null)
                {
                    // Create a new user
                    user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        EmailConfirmed = true // External logins are considered confirmed
                    };
                    
                    var result = await _userManager.CreateAsync(user);
                    
                    if (!result.Succeeded)
                    {
                        var errors = result.Errors.ToDictionary(
                            error => error.Code,
                            error => new[] { error.Description }
                        );
                        return Result<ApplicationUser>.Failure("Failed to create user from external login", errors);
                    }
                    
                    // Add external login info
                    // In a real implementation, you would extract the provider key from the token
                    // await _userManager.AddLoginAsync(user, new UserLoginInfo(provider, "provider-key", provider));
                }
                
                // Ensure the email is confirmed for external logins
                if (!user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
                
                _logger.LogInformation("User logged in with {Provider} provider", provider);
                return Result<ApplicationUser>.Success(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during external login");
                return Result<ApplicationUser>.Failure("External login failed");
            }
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<(string token, string refreshToken)> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(user);

            return (new JwtSecurityTokenHandler().WriteToken(token), refreshToken);
        }

        public async Task<Result<ClaimsPrincipal>> ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return Result<ClaimsPrincipal>.Success(principal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Token validation failed");
                return Result<ClaimsPrincipal>.Failure("Invalid token");
            }
        }

        public async Task<Result<(string token, string refreshToken)>> RefreshTokenAsync(string token, string refreshToken)
        {
            var principal = await ValidateJwtToken(token);
            
            if (!principal.Succeeded)
            {
                return Result<(string token, string refreshToken)>.Failure("Invalid token");
            }
            
            var userId = principal.Data.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return Result<(string token, string refreshToken)>.Failure("Invalid refresh token");
            }
            
            var newTokens = await GenerateJwtToken(user);
            return Result<(string token, string refreshToken)>.Success(newTokens);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}