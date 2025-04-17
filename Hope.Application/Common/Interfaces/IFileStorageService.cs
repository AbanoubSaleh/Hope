using Hope.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface IFileStorageService
    {
        Task<Result<string>> SaveFileAsync(IFormFile file, string folderName, string customFilename = null);
        Task<Result> DeleteFileAsync(string filePath);
        Task<Result<string>> UploadFileAsync(IFormFile file, string folderName);
    }
}