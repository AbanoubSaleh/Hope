using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FileStorageService> _logger;

        public FileStorageService(IWebHostEnvironment environment, ILogger<FileStorageService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<Result<string>> SaveFileAsync(IFormFile file, string folderName, string customFilename)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Result<string>.Failure("File is empty");
                }

                // Create the uploads directory if it doesn't exist
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", folderName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Use the custom filename provided (which contains the report ID)
                var filePath = Path.Combine(uploadsFolder, customFilename);

                // Save the file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Return the relative path for storage in the database
                var relativePath = Path.Combine("uploads", folderName, customFilename).Replace("\\", "/");
                
                _logger.LogInformation("File saved successfully: {FilePath}", relativePath);
                return Result<string>.Success(relativePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving file");
                return Result<string>.Failure($"Error saving file: {ex.Message}");
            }
        }

        public Task<Result> DeleteFileAsync(string filePath)
        {
            try
            {
                // Get the full path
                var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));

                // Check if file exists
                if (!File.Exists(fullPath))
                {
                    _logger.LogWarning("File not found: {FilePath}", filePath);
                    return Task.FromResult(Result.Failure("File not found"));
                }

                // Delete the file
                File.Delete(fullPath);
                
                _logger.LogInformation("File deleted successfully: {FilePath}", filePath);
                return Task.FromResult(Result.Success());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file: {FilePath}", filePath);
                return Task.FromResult(Result.Failure($"Error deleting file: {ex.Message}"));
            }
        }

        public async Task<Result<string>> UploadFileAsync(IFormFile file, string folderName)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Result<string>.Failure("File is empty");
                }

                // Generate a unique filename
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                // Create the uploads directory if it doesn't exist
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", folderName);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Save the file
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Return the relative path for storage in the database
                var relativePath = Path.Combine("uploads", folderName, fileName).Replace("\\", "/");
                
                _logger.LogInformation("File uploaded successfully: {FilePath}", relativePath);
                return Result<string>.Success(relativePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file");
                return Result<string>.Failure($"Error uploading file: {ex.Message}");
            }
        }
    }
}