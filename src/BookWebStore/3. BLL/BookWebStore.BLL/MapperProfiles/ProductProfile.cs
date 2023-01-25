using AutoMapper;
using BookWebStore.BLL.DTO.Product;
using BookWebStore.Domain.Entities;

namespace BookWebStore.BLL.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(destination => destination.Category, optional => 
                    optional.MapFrom(source => source.Category))
                .ForMember(destination => destination.CoverType, optional => 
                    optional.MapFrom(source => source.CoverType))
                .ForAllMembers(opts => opts.Condition((source, destination, sourceMember) =>
                        sourceMember != null));
        }
    }
}