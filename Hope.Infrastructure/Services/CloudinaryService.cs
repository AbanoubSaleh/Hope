using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger<CloudinaryService> _logger;
        private readonly bool _isConfigured;

        public CloudinaryService(IConfiguration configuration, ILogger<CloudinaryService> logger)
        {
            _logger = logger;

            // Get Cloudinary configuration from appsettings.json
            var cloudName = configuration["Cloudinary:CloudName"];
            var apiKey = configuration["Cloudinary:ApiKey"];
            var apiSecret = configuration["Cloudinary:ApiSecret"];

            _isConfigured = !string.IsNullOrEmpty(cloudName) && 
                           !string.IsNullOrEmpty(apiKey) && 
                           !string.IsNullOrEmpty(apiSecret);

            if (!_isConfigured)
            {
                _logger.LogError("Cloudinary configuration is missing or incomplete. Please check your appsettings.json file.");
                // Set a default account to avoid null reference exceptions
                _cloudinary = new Cloudinary(new Account("dummy", "dummy", "dummy"));
                return;
            }

            // Set up Cloudinary account
            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
            _logger.LogInformation("Cloudinary service initialized successfully with cloud name: {CloudName}", cloudName);
        }

        public async Task<Result<string>> UploadImageAsync(IFormFile file, string folderPath = null)
        {
            try
            {
                if (!_isConfigured)
                {
                    _logger.LogError("Cloudinary is not properly configured. Upload operation aborted.");
                    return Result<string>.Failure("Cloudinary service is not properly configured. Please check your application settings.");
                }

                if (file == null || file.Length == 0)
                {
                    return Result<string>.Failure("File is empty");
                }

                // Prepare upload parameters
                var uploadParams = new ImageUploadParams();

                // Set folder if provided
                if (!string.IsNullOrEmpty(folderPath))
                {
                    uploadParams.Folder = folderPath;
                }

                // Read file stream
                using (var stream = file.OpenReadStream())
                {
                    uploadParams.File = new FileDescription(file.FileName, stream);

                    // Upload to Cloudinary
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.Error != null)
                    {
                        _logger.LogError("Cloudinary upload error: {ErrorMessage}", uploadResult.Error.Message);
                        return Result<string>.Failure($"Error uploading to Cloudinary: {uploadResult.Error.Message}");
                    }

                    // Return the secure URL
                    _logger.LogInformation("File uploaded to Cloudinary: {PublicId}", uploadResult.PublicId);
                    return Result<string>.Success(uploadResult.SecureUrl.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file to Cloudinary");
                return Result<string>.Failure($"Error uploading to Cloudinary: {ex.Message}");
            }
        }
    }
}