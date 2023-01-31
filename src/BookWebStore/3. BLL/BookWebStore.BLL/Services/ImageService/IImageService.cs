using BookWebStore.BLL.DTO.Image;
using BookWebStore.BLL.Helpers;

namespace BookWebStore.BLL.Services.PhotoService
{
    public interface IImageService
    {
        Task<ServiceResult<ImageReadDto>> AddPhoto(ImageDto photoDto);

        Task<ServiceResult<bool>> DeletePhoto(int photoId);
    }
}
