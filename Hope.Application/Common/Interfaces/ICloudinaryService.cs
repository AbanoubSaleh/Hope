using Hope.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface ICloudinaryService
    {
        /// <summary>
        /// Uploads an image to Cloudinary
        /// </summary>
        /// <param name="file">The image file to upload</param>
        /// <param name="folderPath">Optional folder path within Cloudinary</param>
        /// <returns>Result containing the Cloudinary URL if successful</returns>
        Task<Result<string>> UploadImageAsync(IFormFile file, string folderPath = null);
    }
}