using AutoMapper;
using BookWebStore.BLL.DTO.Image;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.MapperProfiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDto>().ReverseMap();

            CreateMap<Image, ImageReadDto>();
        }
    }
}
