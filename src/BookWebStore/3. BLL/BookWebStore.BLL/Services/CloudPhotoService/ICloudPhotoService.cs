using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace BookWebStore.BLL.Services.CloudPhotoService
{
    public interface ICloudPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}