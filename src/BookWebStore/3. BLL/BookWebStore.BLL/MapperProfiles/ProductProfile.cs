using AutoMapper;
using BookWebStore.BLL.DTO.Product;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.MapperProfiles
{
    public class ProductProfile : Profile
    {
        //private static Mapper _mapper { get; set; }

        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(destination => destination.Category, optional =>
                    optional.MapFrom(source => source.Category))
                .ForMember(destination => destination.CoverType, optional =>
                    optional.MapFrom(source => source.CoverType))
                .ForMember(destination => destination.ImageUrl, optional =>
                    optional.MapFrom(source => source.Image.Url))
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((source, destination, sourceMember) =>
                        sourceMember != null));
        }

        //private void AddOrUpdate(ProductDto dto, Product product)
        //{
        //    if (dto.Photo.Id == default(Guid))
        //    {
        //        product.Photo.Add(_mapper.Map<Photo>(photoDto));
        //    }
        //    else
        //    {
        //        _mapper.Map(photoDto, user.Photos.SingleOrDefault(c => c.Id == photoDto.Id));
        //    }
        //}
    }
}