using Hope.Application.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface IFaceRecognitionService
    {
        Task<Result<Guid?>> FindMatchingFaceAsync(IFormFile imageFile);
    }
}