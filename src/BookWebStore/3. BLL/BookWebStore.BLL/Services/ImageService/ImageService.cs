using AutoMapper;
using BookWebStore.BLL.DTO.Image;
using BookWebStore.BLL.Helpers;
using BookWebStore.DAL.Repositories.PhotoRepository;
using BookWebStore.Domain.Constants;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.Services.PhotoService
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _photoRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository photoRepository,
            IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ImageReadDto>> AddPhoto(ImageDto photoDto)
        {
            var photo = _mapper.Map<Image>(photoDto);

            photo = await _photoRepository.AddAsync(photo);

            var photoReadDto = _mapper.Map<ImageReadDto>(photo);

            return photoReadDto is not null
                ? ServiceResult<ImageReadDto>.CreateSuccess(photoReadDto)
                : ServiceResult<ImageReadDto>.CreateFailure(Errors.PhotoAddingError);
        }

        public async Task<ServiceResult<bool>> DeletePhoto(int photoId)
        {
            var result = await _photoRepository.DeleteAsync(photoId);

            return result
                ? ServiceResult<bool>.CreateSuccess(result)
                : ServiceResult<bool>.CreateFailure(Errors.PhotoDoesNotExists);
        }
    }
}
